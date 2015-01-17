using System;
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

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}