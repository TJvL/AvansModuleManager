using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DomainContext _context;

        public DomainContext Context
        {
            get { return _context ?? (_context = new DomainContext()); }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(Context);
        }

        public void Dispose()
        {
            Context.SaveChanges();
            Context.Dispose();
        }
    }
}