using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class LeerlijnController : ApiController
    {
        private readonly ILeerlijnRepository _leerlijnRepository;

        public LeerlijnController(ILeerlijnRepository leerlijnRepository)
        {
            _leerlijnRepository = leerlijnRepository;
        }

        // GET: api/Leerlijn
        public IEnumerable<Leerlijn> Get()
        {
            return _leerlijnRepository.GetAllLeerlijnen();
        }

        // GET: api/Leerlijn/5
        public Leerlijn Get(string naam)
        {
            return _leerlijnRepository.GetLeerlijn(naam);
        }
    }
}
