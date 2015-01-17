using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
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

        [HttpGet, Route("api/Competentie/Get/{schooljaar}/{key}")]
        public Competentie GetOne(string schooljaar, string key)
        {
            var competentie = _competentieRepository.GetOne(new object[] { key, schooljaar });
            _competentieRepository.SaveAndClose();
            return competentie;
        }

        [HttpPost, Route("api/Competentie/Delete")]
        public void Delete(Competentie entity)
        {
            _competentieRepository.Delete(entity);
            _competentieRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Competentie/Edit")]
        public void Edit(Competentie entity)
        {
            _competentieRepository.Edit(entity);
            _competentieRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Competentie/Create")]
        public void Create(Competentie entity)
        {
            _competentieRepository.Create(entity);
            _competentieRepository.SaveAndClose();
        }
    }
}
