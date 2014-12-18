using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController, IModuleApiController
    {
        private readonly IGenericRepository<Module> _moduleRepository;

        public ModuleController(IGenericRepository<Module> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpPost, Route("api/Module/GetOverview")]
        public ModuleListViewModel GetOverview(FilterOptionsViewModel arguments)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/ExportOverview")]
        public string ExportOverview(ExportViewModel arguments)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Module/Get/{key}")]
        public Module GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Delete")]
        public bool Delete(Module entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Edit")]
        public bool Edit(Module entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Create")]
        public bool Create(Module entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
