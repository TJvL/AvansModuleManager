using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class OnderdeelController : ApiController, IGenericApiController<Onderdeel>
    {
        private readonly IGenericRepository<Onderdeel> _onderdeelRepository;

         public OnderdeelController(IGenericRepository<Onderdeel> onderdeelRepository)
        {
            _onderdeelRepository = onderdeelRepository;
        }

        [HttpGet, Route("api/Onderdeel/Get")]
        public IEnumerable<Onderdeel> GetAll()
        {
            return _onderdeelRepository.GetAll();
        }

        [HttpGet, Route("api/Onderdeel/Get/{key}")]
        public Onderdeel GetOne(string key)
        {
            var keys = new[] { key };
            return _onderdeelRepository.GetOne(keys);
        }

        [HttpPost, Route("api/Onderdeel/Delete")]
        public bool Delete(Onderdeel entity)
        {
            return _onderdeelRepository.Delete(entity);
        }

        [HttpPost, Route("api/Onderdeel/Edit")]
        public bool Edit(Onderdeel entity)
        {
            return _onderdeelRepository.Edit(entity);
        }

        [HttpPost, Route("api/Onderdeel/Create")]
        public bool Create(Onderdeel entity)
        {
            return _onderdeelRepository.Create(entity);
        }
    }
}