using System.Collections.Generic;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyTagRepository : ITagRepository
    {

        public IEnumerable<Tag> GetAllTags()
        {
            throw new System.NotImplementedException();
        }

        public Tag GetTag(string naam)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateTag(Tag tag)
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
    }
}