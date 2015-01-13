using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class BlokRepository : IGenericRepository<Blok>
    {
        public IEnumerable<Blok> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Blok select b).ToList();
            }
        }

        public Blok GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException();

            using (var context = new DomainContext())
            {
                return (context.Set<Blok>().Find(keys));
            }
        }

        public bool Create(Blok entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }

            return true;
        }

        public bool Delete(Blok entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Blok entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
