using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class CompetentieController : ApiController, IGenericApiController<Competentie>
    {
        private readonly IGenericRepository<Competentie> _competentieRepository;

        public CompetentieController(IGenericRepository<Competentie> competentieRepository)
        {
            _competentieRepository = competentieRepository;
        }

        [HttpGet, Route("api/Competentie/Get")]
        public IEnumerable<Competentie> GetAll()
        {
            return _competentieRepository.GetAll();
        }

        [HttpGet, Route("api/Competentie/Get/{key}")]
        public Competentie GetOne(string key)
        {
            return _competentieRepository.GetOne(key);
        }

        [HttpPost, Route("api/Competentie/Delete")]
        public bool Delete(Competentie entity)
        {
            return _competentieRepository.Delete(entity);
        }

        [HttpPost, Route("api/Competentie/Edit")]
        public bool Edit(Competentie entity)
        {
            return _competentieRepository.Edit(entity);
        }

        [HttpPost, Route("api/Competentie/Create")]
        public bool Create(Competentie entity)
        {
            return _competentieRepository.Create(entity);
        }
    }
}
