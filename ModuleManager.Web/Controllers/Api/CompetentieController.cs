using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class CompetentieController : ApiController
    {
        private readonly ICompetentieRepository _competentieRepository;

        public CompetentieController(ICompetentieRepository competentieRepository)
        {
            _competentieRepository = competentieRepository;
        }

        // GET: api/Competentie
        public IEnumerable<Competentie> Get()
        {
            return _competentieRepository.GetAllCompetenties();
        }

        // GET: api/Competentie/5
        public Competentie Get(string compCode)
        {
            return _competentieRepository.GetCompetentie(compCode);
        }

        // POST: api/Competentie
        public void Post([FromBody]string value)
        {
        }
    }
}
