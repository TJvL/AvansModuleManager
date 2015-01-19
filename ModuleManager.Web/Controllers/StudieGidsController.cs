using System.Linq;
using System.Web.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;

        public StudieGidsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Table
        public ActionResult Index()
        {
            var vm = new StudiegidsViewModel();

            foreach (var ft in _unitOfWork.GetRepository<FaseType>().GetAll())
            {
                var tabellenlijst = new LessenTabelViewModel { FaseType = ft.Type };
                var fasems = _unitOfWork.GetRepository<FaseModules>().GetAll().ToList();
                var fases = _unitOfWork.GetRepository<Fase>().GetAll().ToList();
                //return CollectionA
                //  .Join(CollectionB,
                //      a => new { a.KeyA, a.KeyB },
                //      b => new { b.KeyA, b.KeyB },
                //      (a, b) => new { a, b })
                var joined = fasems
                    .Join(fases,
                        a => new { fnaam = a.FaseNaam, fschooljaar = a.FaseSchooljaar, onaam = a.OpleidingNaam, oschooljaar = a.OpleidingSchooljaar },
                        b => new { fnaam = b.Naam, fschooljaar = b.Schooljaar, onaam = b.OpleidingNaam, oschooljaar = b.OpleidingSchooljaar },
                        (a, b) => new { a, b });
                foreach (var random in joined.Where(src => src.b.FaseType.Equals(tabellenlijst.FaseType)).DistinctBy(src => new { src.a.Blok, src.a.FaseNaam })) // fasemodule collectie WHERE fasetype.EQUALS(ft.Type)
                {
                    var tabel = new LesTabelViewModel { Blok = random.a.Blok, FaseNaam = random.a.FaseNaam };
                    foreach (var fm2 in _unitOfWork.GetRepository<FaseModules>().GetAll()
                        .Where(src => src.Blok.Equals(tabel.Blok))
                        .Where(src => src.FaseNaam.Equals(tabel.FaseNaam))) // WTF DOE IK HIER?!
                    {
                        var keys = new object[] { fm2.ModuleCursusCode, fm2.ModuleSchooljaar };
                        var module = _unitOfWork.GetRepository<Module>().GetOne(keys);
                        var row = Mapper.Map<Module, ModuleTabelViewModel>(module);
                        tabel.Modules.Add(row);
                    }
                    tabellenlijst.Tabellen.Add(tabel);
                }
                vm.Opleidingsfasen.Add(tabellenlijst);
            }

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}