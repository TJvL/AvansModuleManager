using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class FaseController : ApiController, IGenericApiController<Fase>
    {
        private readonly IGenericRepository<Fase> _faseRepository;

        public FaseController(IGenericRepository<Fase> faseRepository)
        {
            _faseRepository = faseRepository;
        }

        [HttpGet, Route("api/Fase/Get")]
        public IEnumerable<Fase> GetAll()
        {
            return _faseRepository.GetAll();
        }

        [HttpGet, Route("api/Fase/Get/{key}")]
        public Fase GetOne(string key)
        {
            return _faseRepository.GetOne(key);
        }

        [HttpPost, Route("api/Fase/Delete")]
        public bool Delete(Fase entity)
        {
            return _faseRepository.Delete(entity);
        }

        [HttpPost, Route("api/Fase/Edit")]
        public bool Edit(Fase entity)
        {
            return _faseRepository.Edit(entity);
        }

        [HttpPost, Route("api/Fase/Create")]
        public bool Create(Fase entity)
        {
            return _faseRepository.Create(entity);
        }
    }
}
