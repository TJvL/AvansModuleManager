using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces;
using System.IO;

namespace ModuleManager.Web.Controllers
{
    public class StudieGidsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExporterService<Competentie> _competentieExporterService;
        private readonly IExporterService<Leerlijn> _leerlijnExporterService;

        public StudieGidsController(IUnitOfWork unitOfWork, IExporterService<Competentie> competentieExporterService, IExporterService<Leerlijn> leerlijnExporterService)
        {
            _unitOfWork = unitOfWork;
            _competentieExporterService = competentieExporterService;
            _leerlijnExporterService = leerlijnExporterService;
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

        [HttpGet, Route("StudieGids/Export/Competenties")]
        public FileStreamResult GetCompetentiesExport() 
        {
            CompetentieExportArguments args = new CompetentieExportArguments() { ExportAll = true };
            var data = _unitOfWork.GetRepository<Competentie>().GetAll();

            var maxSchooljaar = _unitOfWork.GetRepository<Schooljaar>().GetAll().Max(src => src.JaarId);
            var lastYearData = (from element in data where element.Schooljaar.Equals(maxSchooljaar) select element).ToList();

            IExportablePack<Competentie> pack = new CompetentieExportablePack(args, lastYearData);
            Stream fStream = _competentieExporterService.ExportAllAsStream(pack);

            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Competenties.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }

        [HttpGet, Route("StudieGids/Export/Leerlijnen")]
        public FileStreamResult GetLeerlijnenExport()
        {
            LeerlijnExportArguments args = new LeerlijnExportArguments() { ExportAll = true };
            var data = _unitOfWork.GetRepository<Leerlijn>().GetAll();

            var maxSchooljaar = _unitOfWork.GetRepository<Schooljaar>().GetAll().Max(src => src.JaarId);
            var lastYearData = (from element in data where element.Schooljaar.Equals(maxSchooljaar) select element).ToList();

            IExportablePack<Leerlijn> pack = new LeerlijnExportablePack(args, lastYearData);
            Stream fStream = _leerlijnExporterService.ExportAllAsStream(pack);

            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=Competenties.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }
    }
}