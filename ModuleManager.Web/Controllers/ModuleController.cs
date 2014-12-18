using System.Collections.Generic;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers
{

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

        /// <summary>
        /// Methode om de hoofd module overzicht's pagina op te bouwen en te sturen naar de client.
        /// </summary>
        /// <returns>De hoofd module overzicht pagina</returns>
        [HttpGet, Route("Module/Overview")]
        public ActionResult Overview()
        {
            var tagFilters = new List<string>();

            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                ModuleViewModels = _moduleApi.GetOverview(new Arguments()),
                FilterOptions = new FilterOptionsViewModel
                {   // TODO: Vervang deze code door een call naar de relevante database tabellen.
                    Blokken = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
                    FaseNamen =
                        new List<string>
                        {
                            "Software Ontwikeling - Major",
                            "Software Architectuur - Minor",
                            "Informatica - Propedeuse"
                        },
                    Status1 =
                        new List<string>
                        {
                            "Compleet (ongecontroleerd)",
                            "Compleet (gecontroleerd",
                            "Incompleet",
                            "Nieuw"
                        },
                    Leerjaren =
                        new List<int>
                        {
                            1112,
                            1213,
                            1314,
                            1415
                        },
                    ECs = new List<double>
                    {
                        0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5
                    },
                    TagFilter = new List<string>
                    {
                        "Big Data",
                        "Duurzaamheid",
                        "Worstenfabriek"
                    },
                    CompetentieFilter = new List<string>
                    {
                        "Proces analyse",
                        "Modulerrenrnrenn",
                        "Gevaldingen"
                    },
                    LeerlijnFilter = new List<string>
                    {
                        "Je moeder",
                        "Je vader",
                        "je opa",
                        "je oma"
                    }
                }
            };
            return View(moduleOverviewVm);
        }

        /// <summary>
        /// Tijdelijke methode om de docent module overzicht pagina op te roepen.
        /// </summary>
        /// <returns>Docent module overzicht's pagina</returns>
        [HttpGet, Route("Module/Overview_Teacher_Temp")]
        public ActionResult Overview_Teacher_Temp()
        {
            var tagFilters = new List<string>();

            var moduleOverviewVm = new ModuleOverviewViewModel
            {
                ModuleViewModels = _moduleApi.GetOverview(new Arguments()),
                FilterOptions = new FilterOptionsViewModel
                {   // TODO: Vervang deze code door een call naar de relevante database tabellen.
                    Blokken = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
                    FaseNamen =
                        new List<string>
                        {
                            "Software Ontwikeling - Major",
                            "Software Architectuur - Minor",
                            "Informatica - Propedeuse"
                        },
                    Status1 =
                        new List<string>
                        {
                            "Compleet (ongecontroleerd)",
                            "Compleet (gecontroleerd",
                            "Incompleet",
                            "Nieuw"
                        },
                    Leerjaren =
                        new List<int>
                        {
                            1112,
                            1213,
                            1314,
                            1415
                        },
                    ECs = new List<double>
                    {
                        0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5
                    },
                    TagFilter = new List<string>
                    {
                        "Big Data",
                        "Duurzaamheid",
                        "Worstenfabriek"
                    },
                    CompetentieFilter = new List<string>
                    {
                        "Proces analyse",
                        "Modulerrenrnrenn",
                        "Gevaldingen"
                    },
                    LeerlijnFilter = new List<string>
                    {
                        "Je moeder",
                        "Je vader",
                        "je opa",
                        "je oma"
                    }
                }
            };
            return View(moduleOverviewVm);
        }

        [HttpGet, Route("Module/Details/{cursusCode}")]
        public ActionResult Details(string cursusCode)
        {
            return View(_moduleApi.GetOne(cursusCode));
        }

        [HttpGet, Route("Module/Details_Teacher_Temp/{cursusCode}")]
        public ActionResult Details_Teacher_Temp(string cursusCode)
        {
            return View(_moduleApi.GetOne(cursusCode));
        }

        [HttpGet, Route("Module/Edit/{cursusCode}")]
        public ActionResult Edit(string cursusCode)
        {
            return View(_moduleApi.GetOne(cursusCode));
        }

        [HttpPost, Route("Module/Edit")]
        public ActionResult Edit(Module entity)
        {
            var isSucces = _moduleApi.Edit(entity);

            if (isSucces)
            {
                return Redirect("Overview_Teacher_Temp");
            }
            return View(_moduleApi.GetOne(entity.CursusCode));
        }
    }
}