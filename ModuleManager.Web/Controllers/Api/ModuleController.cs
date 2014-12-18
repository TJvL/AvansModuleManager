using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels.PartialViewModel;

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
        public ModuleListViewModel GetOverview(Arguments arguments)
        {
            var modules = _moduleRepository.GetAll();
            var moduleListVm = new ModuleListViewModel(modules.Count());
            var processedData = _filterSorterService.ProcessData(new ModuleQueryablePack(arguments, modules as IQueryable<Module>));

            var returnData = new Collection<ModuleViewModel>();
            foreach (var m in processedData)
            {
                returnData.Add(Mapper.Map<Module, ModuleViewModel>(m));
            }
            moduleListVm.Modules = returnData;

            return moduleListVm;
        }

        [HttpPost, Route("api/Module/ExportOverview")]
        public string ExportOverview(ExportViewModel arguments)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Module/Get/{key}")]
        public Module GetOne(string key)
        {
            return _moduleRepository.GetOne(key);
        }

        [HttpPost, Route("api/Module/Delete")]
        public bool Delete(Module entity)
        {
            return _moduleRepository.Delete(entity);
        }

        [HttpPost, Route("api/Module/Edit")]
        public bool Edit(Module entity)
        {
            return _moduleRepository.Edit(entity);
        }

        [HttpPost, Route("api/Module/Create")]
        public bool Create(Module entity)
        {
            return _moduleRepository.Create(entity);
        }
    }
}
