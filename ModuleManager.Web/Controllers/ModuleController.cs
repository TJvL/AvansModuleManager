using System.Linq;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;

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

        private readonly IFilterSorterService<Module> _filterSorterService; 

        public ModuleController(IGenericRepository<Blok> blokRepository,
            IGenericRepository<Schooljaar> schooljaarRepository, IGenericRepository<Module> moduleRepository, 
            IGenericRepository<Competentie> competentieRepository, IGenericRepository<Leerlijn> leerlijnRepository, 
            IGenericRepository<Tag> tagRepository, IGenericRepository<Fase> faseRepository, IFilterSorterService<Module> filterSorterService)
        {
            _blokRepository = blokRepository;
            _schooljaarRepository = schooljaarRepository;
            _moduleRepository = moduleRepository;
            _competentieRepository = competentieRepository;
            _leerlijnRepository = leerlijnRepository;
            _tagRepository = tagRepository;
            _faseRepository = faseRepository;

            _filterSorterService = filterSorterService;
        }

        /// <summary>
        /// Methode om de hoofd module overzicht's pagina op te bouwen en te sturen naar de client.
        /// </summary>
        /// <returns>De hoofd module overzicht pagina</returns>
        [HttpGet, Route("Module/Overview")]
        public ActionResult Overview()
        {
            //Collect the modules to be shown in the requested overview page.
            var arguments = new Arguments
            {

            };
            var queryPack = new ModuleQueryablePack(arguments, _moduleRepository.GetAll().AsQueryable());
            var modules = _filterSorterService.ProcessData(queryPack).ToList();
            var moduleList = new ModuleListViewModel(modules.Count());
            moduleList.AddModules(modules);

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
                ModuleViewModels = moduleList,
                FilterOptions = filterOptions
            };
            return View(moduleOverviewVm);
        }

        [HttpGet, Route("Module/Details/{cursusCode}")]
        public ActionResult Details(string cursusCode)
        {
            return View(_moduleRepository.GetOne(cursusCode));
        }

        [HttpGet, Route("Module/Edit/{cursusCode}")]
        public ActionResult Edit(string cursusCode)
        {
            return View(_moduleRepository.GetOne(cursusCode));
        }

        [HttpPost, Route("Module/Edit")]
        public ActionResult Edit(Module entity)
        {
            var isSucces = _moduleRepository.Edit(entity);

            if (isSucces)
            {
                return Redirect("Overview_Teacher_Temp");
            }
            return View(_moduleRepository.GetOne(entity.CursusCode));
        }
    }
}