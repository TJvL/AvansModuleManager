using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class NiveauRepository : IGenericRepository<Niveau>
    {
        public IEnumerable<Niveau> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Niveau select b).ToList();
            }
        }

        public Niveau GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Niveau>().Find(keys));
            }
        }

        public bool Create(Niveau entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Niveau entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Niveau entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
