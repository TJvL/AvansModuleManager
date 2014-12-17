using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.UnitOfWork;
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
            throw new System.NotImplementedException();
        }

        [HttpGet, Route("api/Tag/Get/{key}")]
        public Tag GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Tag/Delete")]
        public bool Delete(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Tag/Edit")]
        public bool Edit(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost, Route("api/Tag/Create")]
        public bool Create(Tag entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
