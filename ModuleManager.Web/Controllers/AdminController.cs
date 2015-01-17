using System.Linq;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.UserDAL.Interfaces;
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
        private readonly IUserRepository _userRepository;

        private readonly IFilterSorterService<Module> _filterSorterService;

        public AdminController(IGenericRepository<Blok> blokRepository, IGenericRepository<Status> statusRepository,
            IGenericRepository<Module> moduleRepository, IGenericRepository<Competentie> competentieRepository,
            IGenericRepository<Leerlijn> leerlijnRepository, IGenericRepository<Tag> tagRepository, IGenericRepository<Fase> faseRepository,
            IFilterSorterService<Module> filterSorterService, IUserRepository userRepository)
        {
            _blokRepository = blokRepository;
            _statusRepository = statusRepository;
            _moduleRepository = moduleRepository;
            _competentieRepository = competentieRepository;
            _leerlijnRepository = leerlijnRepository;
            _tagRepository = tagRepository;
            _faseRepository = faseRepository;

            _userRepository = userRepository;

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

            var competenties = _competentieRepository.GetAll().ToArray();
            var leerlijnen = _leerlijnRepository.GetAll().ToArray();
            var tags = _tagRepository.GetAll().ToArray();
            var fases = _faseRepository.GetAll().ToArray();
            var blokken = _blokRepository.GetAll().ToArray();

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

            _moduleRepository.SaveAndClose();
            _competentieRepository.SaveAndClose();
            _leerlijnRepository.SaveAndClose();
            _tagRepository.SaveAndClose();
            _faseRepository.SaveAndClose();
            _blokRepository.SaveAndClose();

            return View(adminCurriculumVm);
        }


        [HttpGet, Route("Admin/UserOverview")]
        public ActionResult UserOverview()
        {
            var userList = _userRepository.GetAll().ToArray();
            var usersListVm = new UserListViewModel(userList.Count());
            usersListVm.AddUsers(userList);

            var overViewvm = new AdminUserManagementViewModel()
            {
                Users = usersListVm
            };

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

            var users = _userRepository.GetAll().AsQueryable();
            var userList = new UserListViewModel(users.Count());
            userList.AddUsers(users);

	        var checkModulesVm = new CheckModulesViewModel
            {
                ModuleViewModels = moduleList,
                Users = userList
	        };

            _moduleRepository.SaveAndClose();
            return View(checkModulesVm);
        }

        [HttpGet, Route("Admin/Archive")]
        public ActionResult Archive()
        {
            return View();
        }

        [HttpPost, Route("Admin/Archive")]
        public ActionResult Archive(string code)
        {
            if (code != "ARCHIVEREN")
            {
                ViewBag.Message = "Invoer incorrect, probeer opnieuw.";
                return View();
            }

            using (var context = new DomainContext())
            {
                context.SP_ArchiveYear();
            }

            return View();
        }
    }
}