﻿using System.Collections.Generic;
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
            return _tagRepository.GetAll();
        }

        [HttpGet, Route("api/Tag/Get/{schooljaar}/{key}")]
        public Tag GetOne(string schooljaar, string key)
        {
            var keys = new[] { schooljaar, key };
            return _tagRepository.GetOne(keys);
        }

        [HttpPost, Route("api/Tag/Delete")]
        public bool Delete(Tag entity)
        {
            return _tagRepository.Delete(entity);
        }

        [HttpPost, Route("api/Tag/Edit")]
        public bool Edit(Tag entity)
        {
            return _tagRepository.Edit(entity);
        }

        [HttpPost, Route("api/Tag/Create")]
        public bool Create(Tag entity)
        {
            return _tagRepository.Create(entity);
        }
    }
}
