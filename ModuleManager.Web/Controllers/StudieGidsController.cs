using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers
{
    public class StudieGidsController : Controller
    {
        private readonly IGenericRepository<Module> _moduleRepository;
        private readonly IGenericRepository<Fase> _faseRepository;
        private readonly IGenericRepository<FaseType> _faseTypeRepository;
        private readonly IGenericRepository<FaseModules> _faseModuleRepository;

        public StudieGidsController(IGenericRepository<Module> moduleRepository, IGenericRepository<Fase> faseRepository, IGenericRepository<FaseModules> faseModuleRepository, IGenericRepository<FaseType> faseTypeRepository)
        {
            _moduleRepository = moduleRepository;
            _faseRepository = faseRepository;
            _faseTypeRepository = faseTypeRepository;
            _faseModuleRepository = faseModuleRepository;
        }

        // GET: Table
        public ActionResult Index()
        {
            var vm = new StudiegidsViewModel();

            foreach (var ft in _faseTypeRepository.GetAll())
            {
                var tabellenlijst = new LessenTabelViewModel { FaseType = ft.Type };
                var fasems = _faseModuleRepository.GetAll().ToList();
                var fases = _faseRepository.GetAll().ToList();
                //return CollectionViewModel.AllMerkProducten
                //  .Join(AvailableReceptMerkProducten,
                //      a => new { a.ProductNaam, a.MerkNaam },
                //      b => new { b.ProductNaam, b.MerkNaam },
                //      (a, b) => new { a, b })
                var joined = fasems
                    .Join(fases,
                        a => new { fnaam = a.FaseNaam, fschooljaar = a.FaseSchooljaar, onaam = a.OpleidingNaam, oschooljaar = a.OpleidingSchooljaar },
                        b => new { fnaam = b.Naam, fschooljaar = b.Schooljaar, onaam = b.OpleidingNaam, oschooljaar = b.OpleidingSchooljaar },
                        (a, b) => new { a, b });
                foreach (var random in joined.Where(src => src.b.FaseType.Equals(tabellenlijst.FaseType)).DistinctBy(src => new { src.a.Blok, src.a.FaseNaam })) // fasemodule collectie WHERE fasetype.EQUALS(ft.Type)
                {
                    var tabel = new LesTabelViewModel { Blok = random.a.Blok, FaseNaam = random.a.FaseNaam };
                    foreach (var fm2 in _faseModuleRepository.GetAll()
                        .Where(src => src.Blok.Equals(tabel.Blok))
                        .Where(src => src.FaseNaam.Equals(tabel.FaseNaam))) // WTF DOE IK HIER?!
                    {
                        var keys = new object[] { fm2.ModuleCursusCode, fm2.ModuleSchooljaar };
                        var row = Mapper.Map<Module, ModuleTabelViewModel>(_moduleRepository.GetOne(keys));
                        tabel.Modules.Add(row);
                    }
                    tabellenlijst.Tabellen.Add(tabel);
                }
                vm.Opleidingsfasen.Add(tabellenlijst);
            }

            return View();
        }
    }
}