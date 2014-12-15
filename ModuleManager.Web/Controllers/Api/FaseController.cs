using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class FaseController : ApiController
    {
        private readonly IFaseRepository _faseRepository;

        public FaseController(IFaseRepository faseRepository)
        {
            _faseRepository = faseRepository;
        }

        // GET: api/Fase
        public IEnumerable<Fase> Get()
        {
            return _faseRepository.GetAllFases();
        }

        // GET: api/Fase/5
        public Fase Get(string naam)
        {
            return _faseRepository.GetFase(naam);
        }

        // POST: api/Fase
        public void Post([FromBody]string value)
        {
        }
    }
}
