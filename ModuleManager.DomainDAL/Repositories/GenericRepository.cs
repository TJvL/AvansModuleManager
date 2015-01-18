using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DomainContext _context;

        public GenericRepository(DomainContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = new DomainContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetOne(object[] keys)
        {
            using (var context = new DomainContext())
            {
                return context.Set<T>().Find(keys);
            }
        }

        public void Create(T entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Delete(T entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Edit(T entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
