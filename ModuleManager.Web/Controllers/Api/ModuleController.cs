using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.Web.ViewModels.RequestViewModels;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController, IModuleApiController
    {
        private readonly IGenericRepository<Module> _moduleRepository;
        private readonly IFilterSorterService<Module> _filterSorterService;

        public ModuleController(IGenericRepository<Module> moduleRepository, IFilterSorterService<Module> filterSorterService)
        {
            _moduleRepository = moduleRepository;
            _filterSorterService = filterSorterService;
        }

        [HttpPost, Route("api/Module/GetOverview")]
        public ModuleListViewModel GetOverview([FromBody] ArgumentsViewModel value)
        {
            var modules = _moduleRepository.GetAll();

            ICollection<string> competentieFilters = null;
            if (value.Filter.Competenties.First() != null) competentieFilters = value.Filter.Competenties;

            ICollection<string> tagFilters = null;
            if (value.Filter.Tags.First() != null) tagFilters = value.Filter.Tags;

            ICollection<string> leerlijnFilters = null;
            if (value.Filter.Leerlijnen.First() != null) leerlijnFilters = value.Filter.Leerlijnen;

            ICollection<string> faseFilters = null;
            if (value.Filter.Fases.First() != null) faseFilters = value.Filter.Fases;

            ICollection<string> blokFilters = null;
            if(value.Filter.Blokken.First() != null) blokFilters = value.Filter.Blokken.ToArray();

            string zoektermFilter = null;
            if (value.Filter.Zoekterm != null) zoektermFilter = value.Filter.Zoekterm;

            string leerjaarFilter = null;
            if (value.Filter.Leerjaar != null) leerjaarFilter = value.Filter.Leerjaar;

            int column = value.OrderBy.Column;
            string columnName;
            switch (column)
            {
                case 1:
                    columnName = "Naam";
                    break;
                case 2:
                    columnName = "CursusCode";
                    break;
                case 3:
                    columnName = "Schooljaar";
                    break;
                case 7:
                    columnName = "Verantwoordelijke";
                    break;
                default:
                    columnName = "Naam";
                    break;
            }

            bool dir;
            if (value.OrderBy.Dir == "desc")
            {
                dir = true;
            }
            else
            {
                dir = false;
            }

            var arguments = new Arguments
            {
                CompetentieFilters = competentieFilters,
                TagFilters = tagFilters,
                LeerlijnFilters = leerlijnFilters,
                FaseFilters = faseFilters,
                BlokFilters = blokFilters,
                ZoektermFilter = zoektermFilter,
                LeerjaarFilter = leerjaarFilter,
                SortBy = columnName,
                SortDesc = dir
            };

            var queryPack = new ModuleQueryablePack(arguments, modules.AsQueryable());
            modules = _filterSorterService.ProcessData(queryPack);

            var modArray = modules.ToArray();
            var moduleListVm = new ModuleListViewModel(modArray.Count());
            moduleListVm.AddModules(modArray);

            _moduleRepository.SaveAndClose();
            return moduleListVm;
        }

        [HttpGet, Route("api/Module/Get/{schooljaar}/{key}")]
        public Module GetOne(string schooljaar, string key)
        {
            var module = _moduleRepository.GetOne(new object[] { schooljaar, key });
            _moduleRepository.SaveAndClose();
            return module;
        }

        [HttpPost, Route("api/Module/Delete")]
        public void Delete(Module entity)
        {
            _moduleRepository.Delete(entity);
            _moduleRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Module/Create")]
        public void Create(Module entity)
        {
            _moduleRepository.Create(entity);
            _moduleRepository.SaveAndClose();
        }
    }
}
