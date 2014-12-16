using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController, IModuleController
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet, Route("api/Module/Get")]
        public IEnumerable<Module> GetAllModules()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Module/Get/{cursusCode}")]
        public Module GetModule(string cursusCode)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Delete/{module}")]
        public bool DeleteModule(Module module)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Edit/{module}")]
        public bool EditModule(Module module)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Module/Create/{module}")]
        public bool CreateModule(Module module)
        {
            throw new System.NotImplementedException();
        }
    }
}
