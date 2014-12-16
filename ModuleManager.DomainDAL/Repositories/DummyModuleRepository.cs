using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.UnitOfWork;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyModuleRepository : IGenericRepository<Module>
    {
        private readonly IUnitOfWork _session;

        public DummyModuleRepository(IUnitOfWork session)
        {
            _session = session;
        }

        public IQueryable<Module> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Module GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Module entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Module entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Module entity)
        {
            throw new System.NotImplementedException();
        }
    }
}