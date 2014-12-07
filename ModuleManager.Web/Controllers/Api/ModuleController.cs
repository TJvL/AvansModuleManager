using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api
{
    public class ModuleController : ApiController
    {
        //TODO: UnitOfWork implementeren inplaats van directe toegang tot de repositories.
        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        // GET: api/Module
        public IEnumerable<Module> Get()
        {
            return _moduleRepository.GetAllModules();
        }

        // GET: api/Module/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Module
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Module/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Module/5
        public void Delete(int id)
        {
        }
    }
}
