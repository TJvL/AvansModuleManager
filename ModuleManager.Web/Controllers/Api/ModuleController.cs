using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController, IGenericApiController<Module>
    {
        private readonly IGenericRepository<Module> _moduleRepository;

        public ModuleController(IGenericRepository<Module> moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet, Route("api/Module/Get")]
        public IEnumerable<Module> GetAll()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Module/Get/{key}")]
        public Module GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Delete/{module}")]
        public bool Delete(Module entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Edit/{module}")]
        public bool Edit(Module entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Create/{module}")]
        public bool Create(Module entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
