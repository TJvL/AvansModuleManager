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
using ModuleManager.Web.ViewModels.RequestViewModels;
using System.Collections.Generic;
using System;

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
        private readonly IFilterSorterService<Module> _filterSorterService;

        public ModuleController(IGenericRepository<Blok> blokRepository,
            IGenericRepository<Schooljaar> schooljaarRepository, IGenericRepository<Module> moduleRepository, 
            IGenericRepository<Competentie> competentieRepository, IGenericRepository<Leerlijn> leerlijnRepository, 
            IGenericRepository<Tag> tagRepository, IGenericRepository<Fase> faseRepository,
            IExporterService<Module> moduleExporterService, IFilterSorterService<Module> filterSorterService)
        {
            _blokRepository = blokRepository;
            _schooljaarRepository = schooljaarRepository;
            _moduleRepository = moduleRepository;
            _competentieRepository = competentieRepository;
            _leerlijnRepository = leerlijnRepository;
            _tagRepository = tagRepository;
            _faseRepository = faseRepository;

            _moduleExporterService = moduleExporterService;
            _filterSorterService = filterSorterService;
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
            var module = _moduleRepository.GetOne(new object[] {schooljaar, cursusCode});
            _moduleRepository.SaveAndClose();
            return View(module);
        }

        [HttpGet, Route("Module/Edit/{schooljaar}/{cursusCode}")]
        public ActionResult Edit(string schooljaar, string cursusCode)
        {
            var module = _moduleRepository.GetOne(new object[] { schooljaar, cursusCode });
            _moduleRepository.SaveAndClose();
            return View(module);
        }

        [HttpPost, Route("Module/Edit")]
        public ActionResult Edit(Module entity)
        {
            _moduleRepository.Edit(entity);

            var module = _moduleRepository.GetOne(new object[] { entity.Schooljaar.ToString(), entity.CursusCode });
            _moduleRepository.SaveAndClose();

            return View(module);
        }

        //PDF Download Code

        [HttpGet, Route("Module/Export/{schooljaar}/{cursusCode}")]
        public FileStreamResult ExportSingleModule(string schooljaar, string cursusCode)
        {
            Stream fStream = _moduleExporterService.ExportAsStream(_moduleRepository.GetOne(new object[]{schooljaar, cursusCode}));
            _moduleRepository.SaveAndClose();

            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=form.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }

        //Kijk hier even naar, wat je wilt met input...
        [HttpPost, Route("Module/ExportAll")]
        public FileStreamResult ExportAllModules(ExportArgumentsViewModel value)
        {
            var modules = _moduleRepository.GetAll();

            ICollection<string> competentieFilters = null;
            if (value.Filters.Competenties.First() != null) competentieFilters = value.Filters.Competenties;

            ICollection<string> tagFilters = null;
            if (value.Filters.Tags.First() != null) tagFilters = value.Filters.Tags;

            ICollection<string> leerlijnFilters = null;
            if (value.Filters.Leerlijnen.First() != null) leerlijnFilters = value.Filters.Leerlijnen;

            ICollection<string> faseFilters = null;
            if (value.Filters.Fases.First() != null) faseFilters = value.Filters.Fases;

            ICollection<string> blokFilters = null;
            if ((value.Filters.Blokken.First() != null)&&(value.Filters.Blokken.First() != "")) blokFilters = value.Filters.Blokken;

            string zoektermFilter = null;
            if (value.Filters.Zoekterm != null) zoektermFilter = value.Filters.Zoekterm;

            int leerjaarFilter = 0;
            if (value.Filters.Leerjaar != null) leerjaarFilter = Convert.ToInt32(value.Filters.Leerjaar);

            var arguments = new Arguments
        {
                CompetentieFilters = competentieFilters,
                TagFilters = tagFilters,
                LeerlijnFilters = leerlijnFilters,
                FaseFilters = faseFilters,
                BlokFilters = blokFilters,
                ZoektermFilter = zoektermFilter,
                LeerjaarFilter = leerjaarFilter
            };

            var queryPack = new ModuleQueryablePack(arguments, modules.AsQueryable());
            modules = _filterSorterService.ProcessData(queryPack);

            var exportArguments = new ExportArguments
            {
                ExportCursusCode = value.Export.CursusCode,
                ExportNaam = value.Export.Naam,
                ExportBeschrijving = value.Export.Beschrijving,
                ExportAlgInfo = value.Export.AlgemeneBeschrijving,
                ExportStudieBelasting = value.Export.Studiebelasting,
                ExportOrganisatie = value.Export.Organisatie,
                ExportWeekplanning = value.Export.Weekplanning,
                ExportBeoordeling = value.Export.Beoordeling,
                ExportLeermiddelen = value.Export.Leermiddelen,
                ExportLeerdoelen = value.Export.Leerdoelen,
                ExportCompetenties = value.Export.Competenties,
                ExportLeerlijnen = value.Export.Leerlijnen,
                ExportTags = value.Export.Tags
            };

            var exportablePack = new ModuleExportablePack(exportArguments, modules);

            BufferedStream fStream = _moduleExporterService.ExportAllAsStream(exportablePack);
            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=form.pdf");

            return new FileStreamResult(fStream, "application/pdf");
        }
    }
}