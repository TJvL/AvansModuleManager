using System.Web.Mvc;
using ModuleManager.DomainDAL;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers {

    public class AdminController : Controller
    {

        private readonly IModuleApiController _moduleApi;
        private readonly IGenericApiController<Competentie> _competentieApi;
        private readonly IGenericApiController<Leerlijn> _leerlijnApi;
        private readonly IGenericApiController<Tag> _tagApi;
        private readonly IGenericApiController<Fase> _faseApi;

        public AdminController(IModuleApiController moduleApi, IGenericApiController<Competentie> competentieApi,
            IGenericApiController<Leerlijn> leerlijnApi, IGenericApiController<Tag> tagApi,
            IGenericApiController<Fase> faseApi)
        {
            _moduleApi = moduleApi;
            _competentieApi = competentieApi;
            _leerlijnApi = leerlijnApi;
            _tagApi = tagApi;
            _faseApi = faseApi;
        }
        
        [HttpGet]
        public ActionResult Index() {
            //Overview page
            return View();
        }

        [HttpGet]
        public ActionResult Curriculum() {
            //Toevoegen/verwijderen/bewerken van leerijnen, tags en competenties doormiddel van pop-up??
            //Toevoegen van Module is aparte POST
            return View();
        }

        [HttpGet]
        public ActionResult UserManagement() {
            return View();
        }

        [HttpGet]
        public ActionResult CheckModules() {
            //herinneringen sturen doormiddel van pop-up/api??
            return View();
        }

        [HttpGet]
        public ActionResult Archive() {
            return View();
        }
    }
}