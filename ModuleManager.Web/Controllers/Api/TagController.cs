using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class TagController : ApiController
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: api/Tag
        public IEnumerable<Tag> Get()
        {
            return _tagRepository.GetAllTags();
        }

        // GET: api/Tag/5
        public Tag Get(string naam)
        {
            return _tagRepository.GetTag(naam);
        }

        // POST: api/Tag
        public void Post([FromBody]string value)
        {
        }
    }
}
