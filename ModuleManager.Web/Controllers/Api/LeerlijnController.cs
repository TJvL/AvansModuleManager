using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class LeerlijnController : ApiController, IGenericApiController<Leerlijn>
    {
        private readonly IGenericRepository<Leerlijn> _leerlijnRepository;

        public LeerlijnController(IGenericRepository<Leerlijn> leerlijnRepository)
        {
            _leerlijnRepository = leerlijnRepository;
        }

        [HttpGet, Route("api/Leerlijn/Get")]
        public IEnumerable<Leerlijn> GetAll()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Leerlijn/Get/{key}")]
        public Leerlijn GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Leerlijn/Delete/{entity}")]
        public bool Delete(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Leerlijn/Edit/{entity}")]
        public bool Edit(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Leerlijn/Create/{entity}")]
        public bool Create(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
