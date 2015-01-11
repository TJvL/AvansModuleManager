using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers
{

    public class AdminController : Controller
    {
        private readonly IGenericRepository<Blok> _blokRepository;
        private readonly IGenericRepository<Status> _statusRepository;
        private readonly IGenericRepository<Module> _moduleRepository;
        private readonly IGenericRepository<Competentie> _competentieRepository;
        private readonly IGenericRepository<Leerlijn> _leerlijnRepository;
        private readonly IGenericRepository<Tag> _tagRepository;
        private readonly IGenericRepository<Fase> _faseRepository;

        private readonly IFilterSorterService<Module> _filterSorterService; 

        public AdminController(IGenericRepository<Blok> blokRepository, IGenericRepository<Status> statusRepository, 
            IGenericRepository<Module> moduleRepository, IGenericRepository<Competentie> competentieRepository, 
            IGenericRepository<Leerlijn> leerlijnRepository, IGenericRepository<Tag> tagRepository, IGenericRepository<Fase> faseRepository, 
            IFilterSorterService<Module> filterSorterService)
        {
            _blokRepository = blokRepository;
            _statusRepository = statusRepository;
            _moduleRepository = moduleRepository;
            _competentieRepository = competentieRepository;
            _leerlijnRepository = leerlijnRepository;
            _tagRepository = tagRepository;
            _faseRepository = faseRepository;

            _filterSorterService = filterSorterService;
        }

        [HttpGet, Route("Admin/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("Admin/Curriculum")]
        public ActionResult Curriculum()
        {
            var arguments = new Arguments
            {

            };
            var queryPack = new ModuleQueryablePack(arguments, _moduleRepository.GetAll().AsQueryable());
            var modules = _filterSorterService.ProcessData(queryPack).ToList();
            var moduleList = new ModuleListViewModel(modules.Count());
            moduleList.AddModules(modules);

            var competenties = _competentieRepository.GetAll();
            var leerlijnen = _leerlijnRepository.GetAll();
            var tags = _tagRepository.GetAll();
            var fases = _faseRepository.GetAll();
            var blokken = _blokRepository.GetAll();

            var filterOptions = new FilterOptionsViewModel();
            filterOptions.AddFases(fases);
            filterOptions.AddBlokken(blokken);

            var adminCurriculumVm = new AdminCurriculumViewModel
            {
                Competenties = competenties,
                Leerlijn = leerlijnen,
                Tags = tags,
                Fases = fases,
                ModuleViewModels = moduleList,
                FilterOptions = filterOptions
            };
            return View(adminCurriculumVm);
        }


        [HttpGet, Route("Admin/UserOverview")]
        public ActionResult UserOverview()
        {

            var mocList = new List<UserViewModel>()
            {
                new UserViewModel()
                {                    
                    Username = "Friet",
                    UserEmail = "Friet@piet.nl",
                    UserRole = "Teacher"
                },
                new UserViewModel()
                {
                    Username = "Pees",
                    UserEmail = "Pees@piet.nl",
                    UserRole = "Adim"
                },
                new UserViewModel()
                {
                    Username = "Arie",
                    UserEmail = "Kanarie@piet.nl",
                    UserRole = "Teacher"
                },
                new UserViewModel()
                {
                    Username = "Tom",                   
                    UserEmail = "Bom@piet.nl",
                    UserRole = "Admin"
                }
            };

            var overViewvm = new AdminUserManagementViewModel()
            {
                Users = new UserListViewModel(mocList.Count) 
                { 
                    Users = mocList
                }
            };

            // TODO: Implementeer ViewModel en return deze.
            return View(overViewvm);
        }

        [HttpGet, Route("Admin/CheckModules")]
        public ActionResult CheckModules()
        {
            var arguments = new Arguments
            {

            };
            var queryPack = new ModuleQueryablePack(arguments, _moduleRepository.GetAll().AsQueryable());
            var modules = _filterSorterService.ProcessData(queryPack).ToList();
            var moduleList = new ModuleListViewModel(modules.Count());
            moduleList.AddModules(modules);

            var filterOptions = new FilterOptionsViewModel();
            filterOptions.AddBlokken(_blokRepository.GetAll());
            filterOptions.AddFases(_faseRepository.GetAll());
            filterOptions.AddStatuses(_statusRepository.GetAll());

            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                ModuleViewModels = moduleList,
                FilterOptions = filterOptions
            };
            return View(moduleOverviewVm);
        }

        [HttpGet, Route("Admin/Archive")]
        public ActionResult Archive()
        {
            return View();
        }
    }
}