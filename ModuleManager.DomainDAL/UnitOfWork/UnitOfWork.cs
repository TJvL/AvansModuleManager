using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DomainContext _context;

        public DomainContext Context
        {
            get { return _context ?? (_context = new DomainContext()); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}