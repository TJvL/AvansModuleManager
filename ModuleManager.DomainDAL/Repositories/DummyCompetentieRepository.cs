using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using ModuleManager.DomainDAL.UnitOfWork;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyCompetentieRepository : IGenericRepository<Competentie>
    {
        private readonly IUnitOfWork _session;

        public DummyCompetentieRepository(IUnitOfWork session)
        {
            _session = session;
        }

        public IQueryable<Competentie> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Competentie GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Competentie entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Competentie entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Competentie entity)
        {
            throw new System.NotImplementedException();
        }
    }
}