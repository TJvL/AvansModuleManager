using System.Collections.Generic;
using System.Linq;
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
            var leerlijnen = _leerlijnRepository.GetAll().ToArray();
            _leerlijnRepository.SaveAndClose();
            return leerlijnen;
        }

        [HttpGet, Route("api/Leerlijn/Get/{schooljaar}/{key}")]
        public Leerlijn GetOne(string schooljaar, string key)
        {
            var leerlijn = _leerlijnRepository.GetOne(new object[] { key, schooljaar });
            _leerlijnRepository.SaveAndClose();
            return leerlijn;
        }

        [HttpPost, Route("api/Leerlijn/Delete")]
        public void Delete(Leerlijn entity)
        {
            _leerlijnRepository.Delete(entity);
            _leerlijnRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Leerlijn/Edit")]
        public void Edit(Leerlijn entity)
        {
            _leerlijnRepository.Edit(entity);
            _leerlijnRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Leerlijn/Create")]
        public void Create(Leerlijn entity)
        {
            _leerlijnRepository.Create(entity);
            _leerlijnRepository.SaveAndClose();
        }
    }
}
