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
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Fase/Get/{key}")]
        public Fase GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Fase/Delete/{entity}")]
        public bool Delete(Fase entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Fase/Edit/{entity}")]
        public bool Edit(Fase entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Fase/Create/{entity}")]
        public bool Create(Fase entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
