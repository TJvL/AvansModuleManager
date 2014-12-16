using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.UnitOfWork;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyFaseRepository : IGenericRepository<Fase>
    {
        private readonly IUnitOfWork _session;

        public DummyFaseRepository(IUnitOfWork session)
        {
            _session = session;
        }

        public IQueryable<Fase> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Fase GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Fase entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Fase entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Fase entity)
        {
            throw new System.NotImplementedException();
        }
    }
}