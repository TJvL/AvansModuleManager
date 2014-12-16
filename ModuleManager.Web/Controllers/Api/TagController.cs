using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class TagController : ApiController, ITagController
    {
        private readonly ITagRepository _tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            throw new System.NotImplementedException();
        }

        public Tag GetTag(string naam)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public bool EditTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}
