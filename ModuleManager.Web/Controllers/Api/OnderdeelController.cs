using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class OnderdeelController : ApiController, IGenericApiController<Leerlijn> // TODO: replace-all 'Leerlijn' => 'Onderdeel'
    {
        private readonly IGenericRepository<Leerlijn> _onderdeelRepository;

        public OnderdeelController(IGenericRepository<Leerlijn> onderdeelRepository)
        {
            _onderdeelRepository = onderdeelRepository;
        }

        [HttpGet, Route("api/Onderdeel/Get")]
        public IEnumerable<Leerlijn> GetAll()
        {
            return _onderdeelRepository.GetAll();
        }

        [HttpGet, Route("api/Onderdeel/Get/{schooljaar}/{key}")]
        public Leerlijn GetOne(string schooljaar, string key) // TODO: Pas keys aan
        {
            var keys = new[] { schooljaar, key };
            return _onderdeelRepository.GetOne(keys);
        }

        [HttpPost, Route("api/Onderdeel/Delete")]
        public bool Delete(Leerlijn entity)
        {
            return _onderdeelRepository.Delete(entity);
        }

        [HttpPost, Route("api/Onderdeel/Edit")]
        public bool Edit(Leerlijn entity)
        {
            return _onderdeelRepository.Edit(entity);
        }

        [HttpPost, Route("api/Onderdeel/Create")]
        public bool Create(Leerlijn entity)
        {
            return _onderdeelRepository.Create(entity);
        }
    }
}