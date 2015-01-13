using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class StatusRepository : IGenericRepository<Status>
    {
        public IEnumerable<Status> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Status select b).ToList();
            }
        }

        public Status GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Status>().Find(keys));
            }
        }

        public bool Create(Status entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Status entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Status entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
