using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
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
            return _leerlijnRepository.GetAll();
        }

        [HttpGet, Route("api/Leerlijn/Get/{key}")]
        public Leerlijn GetOne(string key)
        {
            return _leerlijnRepository.GetOne(key);
        }

        [HttpPost, Route("api/Leerlijn/Delete")]
        public bool Delete(Leerlijn entity)
        {
            return _leerlijnRepository.Delete(entity);
        }

        [HttpPost, Route("api/Leerlijn/Edit")]
        public bool Edit(Leerlijn entity)
        {
            return _leerlijnRepository.Edit(entity);
        }

        [HttpPost, Route("api/Leerlijn/Create")]
        public bool Create(Leerlijn entity)
        {
            return _leerlijnRepository.Create(entity);
        }
    }
}
