using System.Linq;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.BusinessLogic.Services;
using System.IO;
using ModuleManager.BusinessLogic.Interfaces;

namespace ModuleManager.Web.Controllers
{

    public class ModuleController : Controller
    {
        private readonly IGenericRepository<Blok> _blokRepository;
        private readonly IGenericRepository<Schooljaar> _schooljaarRepository;
        private readonly IGenericRepository<Module> _moduleRepository;
        private readonly IGenericRepository<Competentie> _competentieRepository;
        private readonly IGenericRepository<Leerlijn> _leerlijnRepository;
        private readonly IGenericRepository<Tag> _tagRepository;
        private readonly IGenericRepository<Fase> _faseRepository;

        private readonly IExporterService<Module> _moduleExporterService;

        public ModuleController(IGenericRepository<Blok> blokRepository,
            IGenericRepository<Schooljaar> schooljaarRepository, IGenericRepository<Module> moduleRepository, 
            IGenericRepository<Competentie> competentieRepository, IGenericRepository<Leerlijn> leerlijnRepository, 
            IGenericRepository<Tag> tagRepository, IGenericRepository<Fase> faseRepository, IExporterService<Module> moduleExporterService)
        {
            _blokRepository = blokRepository;
            _schooljaarRepository = schooljaarRepository;
            _moduleRepository = moduleRepository;
            _competentieRepository = competentieRepository;
            _leerlijnRepository = leerlijnRepository;
            _tagRepository = tagRepository;
            _faseRepository = faseRepository;

            _moduleExporterService = moduleExporterService;
        }

        /// <summary>
        /// Methode om de hoofd module overzicht's pagina op te bouwen en te sturen naar de client.
        /// </summary>
        /// <returns>De hoofd module overzicht pagina</returns>
        [HttpGet, Route("Module/Overview")]
        public ActionResult Overview()
        {
            //Collect the possible filter options the user can choose.
            var filterOptions = new FilterOptionsViewModel();
            filterOptions.AddBlokken(_blokRepository.GetAll());
            filterOptions.AddCompetenties(_competentieRepository.GetAll());
            filterOptions.AddECs();
            filterOptions.AddFases(_faseRepository.GetAll());
            filterOptions.AddLeerjaren(_schooljaarRepository.GetAll());
            filterOptions.AddLeerlijnen(_leerlijnRepository.GetAll());
            filterOptions.AddTags(_tagRepository.GetAll());

            //Construct the ViewModel.
            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                FilterOptions = filterOptions
            };
            return View(moduleOverviewVm);
        }

        [HttpGet, Route("Module/Details/{schooljaar}/{cursusCode}")]
        public ActionResult Details(string schooljaar, string cursusCode)
        {
            var keys = new[] { schooljaar, cursusCode };
            return View(_moduleRepository.GetOne(keys));
        }

        [HttpGet, Route("Module/Edit/{schooljaar}/{cursusCode}")]
        public ActionResult Edit(string schooljaar, string cursusCode)
        {
            var keys = new[] { schooljaar, cursusCode };
            return View(_moduleRepository.GetOne(keys));
        }

        [HttpPost, Route("Module/Edit")]
        public ActionResult Edit(Module entity)
        {
            var isSucces = _moduleRepository.Edit(entity);

            if (isSucces)
            {
                return Redirect("Overview");
            }
            var keys = new[] { entity.Schooljaar.ToString(), entity.CursusCode };
            return View(_moduleRepository.GetOne(keys));
        }

        //PDF Download Code

        [HttpGet, Route("Module/Export/{schooljaar}/{cursusCode}")]
        public FileStreamResult ExportSingleModule(string schooljaar, string cursusCode)
        {
            Stream fStream = _moduleExporterService.ExportAsStream(_moduleRepository.GetOne(new object[]{schooljaar, cursusCode}));
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=form.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }

        //Kijk hier even naar, wat je wilt met input...
        [HttpPost, Route("Module/ExportAll")]
        public FileStreamResult ExportAllModules(IExportablePack<Module> entity)
        {
            Stream fStream = _moduleExporterService.ExportAllAsStream(entity);
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=form.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }
    }
}