using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.UnitOfWork;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyTagRepository : IGenericRepository<Tag>
    {
        private readonly IUnitOfWork _session;

        public DummyTagRepository(IUnitOfWork session)
        {
            _session = session;
        }

        public IQueryable<Tag> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Tag GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Tag entity)
        {
            throw new System.NotImplementedException();
        }
    }
}