using System.Collections.Generic;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.UserDAL;
using ModuleManager.Web.DataTablesMapping;

namespace ModuleManager.Web.Controllers
{

    public class AdminController : Controller
    {
        // TODO: Implementeer de User API om user data op te halen voor display.
        private readonly IModuleApiController _moduleApi;
        private readonly IGenericApiController<Competentie> _competentieApi;
        private readonly IGenericApiController<Leerlijn> _leerlijnApi;
        private readonly IGenericApiController<Tag> _tagApi;
        private readonly IGenericApiController<Fase> _faseApi;

        private readonly IGenericRepository<Blok> _blokRepository;
        private readonly IGenericRepository<Status> _statusRepository; 

        public AdminController(IModuleApiController moduleApi, IGenericApiController<Competentie> competentieApi,
            IGenericApiController<Leerlijn> leerlijnApi, IGenericApiController<Tag> tagApi,
            IGenericApiController<Fase> faseApi, IGenericRepository<Blok> blokRepository, IGenericRepository<Status> statusRepository)
        {
            _moduleApi = moduleApi;
            _competentieApi = competentieApi;
            _leerlijnApi = leerlijnApi;
            _tagApi = tagApi;
            _faseApi = faseApi;

            _blokRepository = blokRepository;
            _statusRepository = statusRepository;
        }

        [HttpGet, Route("Admin/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("Admin/Curriculum")]
        public ActionResult Curriculum()
        {
            var competenties = _competentieApi.GetAll();
            var leerlijnen = _leerlijnApi.GetAll();
            var tags = _tagApi.GetAll();
            var fases = _faseApi.GetAll();
            var blokken = _blokRepository.GetAll();

            var filterOptions = new FilterOptionsViewModel();
            filterOptions.AddFases(fases);
            filterOptions.AddBlokken(blokken);

            var request = new CustomDataTablesRequest
            {
                Arguments = new FilterSorterArguments
                {

                }
            };
            var adminCurriculumVm = new AdminCurriculumViewModel
            {
                Competenties = competenties,
                Leerlijn = leerlijnen,
                Tags = tags,
                Fases = fases,                //TODO: Toevoegen van start filter argumenten?
                ModuleViewModels = _moduleApi.GetOverview(request),
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
            var filterOptions = new FilterOptionsViewModel();
            filterOptions.AddBlokken(_blokRepository.GetAll());
            filterOptions.AddFases(_faseApi.GetAll());
            filterOptions.AddStatuses(_statusRepository.GetAll());

            var request = new CustomDataTablesRequest
            {
                Arguments = new FilterSorterArguments
                {

                }
            };
            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                ModuleViewModels = _moduleApi.GetOverview(request),
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