using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.UnitOfWork;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyLeerlijnRepository : IGenericRepository<Leerlijn>
    {
        private readonly IUnitOfWork _session;

        public DummyLeerlijnRepository(IUnitOfWork session)
        {
            _session = session;
        }

        public IQueryable<Leerlijn> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Leerlijn GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Leerlijn entity)
        {
            throw new System.NotImplementedException();
        }
    }
}