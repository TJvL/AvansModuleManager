using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
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
            var fases =_faseRepository.GetAll().ToArray();
            _faseRepository.SaveAndClose();
            return fases;
        }

        [HttpGet, Route("api/Fase/Get/{schooljaar}/{key}")]
        public Fase GetOne(string schooljaar, string key)
        {
            var fase = _faseRepository.GetOne(new object[] { key, schooljaar });
            _faseRepository.SaveAndClose();
            return fase;
        }

        [HttpPost, Route("api/Fase/Delete")]
        public void Delete(Fase entity)
        {
            _faseRepository.Delete(entity);
            _faseRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Fase/Edit")]
        public void Edit(Fase entity)
        {
            _faseRepository.Edit(entity);
            _faseRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Fase/Create")]
        public void Create(Fase entity)
        {
            _faseRepository.Create(entity);
            _faseRepository.SaveAndClose();
        }
    }
}
