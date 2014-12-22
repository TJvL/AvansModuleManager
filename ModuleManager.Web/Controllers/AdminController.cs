using System.Collections.Generic;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;

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

        [HttpGet, Route("Admin/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("Admin/Curriculum")]
        public ActionResult Curriculum()
        {
            var adminCurriculumVm = new AdminCurriculumViewModel
            {
                Competenties = _competentieApi.GetAll(),
                Leerlijn = _leerlijnApi.GetAll(),
                Tags = _tagApi.GetAll(),
                Fases = _faseApi.GetAll(),                //TODO: Toevoegen van start filter argumenten?
                ModuleViewModels = _moduleApi.GetOverview(new Arguments()),
                FilterOptions = new FilterOptionsViewModel
                {   // TODO: Vervang deze code door een call naar de relevante database tabellen.
                    Blokken = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" },
                    FaseNamen =
                        new List<string>
                        {
                            "Software Ontwikeling - Major", 
                            "Software Architectuur - Minor", 
                            "Informatica - Propedeuse"
                        }
                }
            };
            return View(adminCurriculumVm);
        }


        [HttpGet, Route("Admin/UserOverview")]
        public ActionResult UserOverview()
        {
            // TODO: Implementeer ViewModel en return deze.
            return View();
        }

        [HttpGet, Route("Admin/CheckModules")]
        public ActionResult CheckModules()
        {
            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                ModuleViewModels = _moduleApi.GetOverview(new Arguments()),
                FilterOptions = new FilterOptionsViewModel
                {   // TODO: Vervang deze code door een call naar de relevante database tabellen.
                    Blokken = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" },
                    FaseNamen =
                        new List<string>
                        {
                            "Software Ontwikeling - Major",
                            "Software Architectuur - Minor",
                            "Informatica - Propedeuse"
                        },
                    Statussen =
                        new List<string>
                        {
                            "Compleet (ongecontroleerd)",
                            "Compleet (gecontroleerd",
                            "Incompleet",
                            "Nieuw"
                        }
                }
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