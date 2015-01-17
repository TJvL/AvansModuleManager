using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class TagController : ApiController, IGenericApiController<Tag>
    {
        private readonly IGenericRepository<Tag> _tagRepository;

        public TagController(IGenericRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet, Route("api/Tag/Get")]
        public IEnumerable<Tag> GetAll()
        {
            var tags = _tagRepository.GetAll().ToArray();
            _tagRepository.SaveAndClose();
            return tags;
        }

        [HttpGet, Route("api/Tag/Get/{schooljaar}/{key}")]
        public Tag GetOne(string schooljaar, string key)
        {
            var tag = _tagRepository.GetOne(new object[] { schooljaar, key });
            _tagRepository.SaveAndClose();
            return tag;
        }

        [HttpPost, Route("api/Tag/Delete")]
        public void Delete(Tag entity)
        {
            _tagRepository.Delete(entity);
            _tagRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Tag/Edit")]
        public void Edit(Tag entity)
        {
            _tagRepository.Edit(entity);
            _tagRepository.SaveAndClose();
        }

        [HttpPost, Route("api/Tag/Create")]
        public void Create(Tag entity)
        {
            _tagRepository.Create(entity);
            _tagRepository.SaveAndClose();
        }
    }
}
