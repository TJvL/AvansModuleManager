using System.Web.Mvc;
using ModuleManager.DomainDAL;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers {

    public class ModuleController : Controller
    {
        private readonly IModuleApiController _moduleApi;
        private readonly IGenericApiController<Competentie> _competentieApi;
        private readonly IGenericApiController<Leerlijn> _leerlijnApi;
        private readonly IGenericApiController<Tag> _tagApi;
        private readonly IGenericApiController<Fase> _faseApi;

        public ModuleController(IModuleApiController moduleApi, IGenericApiController<Competentie> competentieApi,
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
        public ActionResult Overview() {
            return View();
        }

        [HttpGet]
        public ActionResult Overview_Teacher_Temp() {
            return View();
        }

        [HttpGet]
        public ActionResult Details() {
            return View();
        }

        [HttpGet]
        public ActionResult Details_Teacher_Temp() {
            return View();
        }

        [HttpGet]
        public ActionResult Edit() {
            return View();
        }

    }
}