using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.DomainDAL;

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

        // GET: api/Module/IIIN-DATAB3
        [Route("api/Module/{cursusCode}")]
        public Module Get(string cursusCode)
        {
            return _moduleRepository.GetModule(cursusCode);
        }

        // POST: api/Module
        //public void Post([FromBody]string value)
        //{
        //}
    }
}
