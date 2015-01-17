using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class OnderdeelRepository : IGenericRepository<Onderdeel>
    {
        public IEnumerable<Onderdeel> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from o in context.Onderdeel select o).ToList();
            }
        }

        public Onderdeel GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Onderdeel>().Find(keys));
            }
        }

        public bool Create(Onderdeel entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Onderdeel entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Onderdeel entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
