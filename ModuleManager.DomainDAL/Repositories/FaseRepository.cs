using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;
namespace ModuleManager.DomainDAL.Repositories
{
    public class FaseRepository : IGenericRepository<Fase>
    {
        public IEnumerable<Fase> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Fase select b).ToList();
            }
        }

        public Fase GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Fase>().Find(keys));
            }
        }

        public bool Create(Fase entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Fase entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Fase entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}