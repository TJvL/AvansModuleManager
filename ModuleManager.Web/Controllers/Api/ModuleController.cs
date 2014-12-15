using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        // GET: api/Module
        [Route("api/Module")]
        public IEnumerable<Module> Get()
        {
            return _moduleRepository.GetAllModules();
        }

        //POST: api/Module
        public void Post([FromBody]Module module)
        {
        }
    }
}
