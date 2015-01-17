using System;
using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class FaseModulesRepository : IGenericRepository<FaseModules>
    {
        public IEnumerable<FaseModules> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.FaseModules select b).ToList();
            }
        }

        public FaseModules GetOne(object[] keys)
        {
            if (keys.Length != 6)
                throw new ArgumentException();

            using (var context = new DomainContext())
            {
                return (context.Set<FaseModules>().Find(keys));
            }
        }

        public bool Create(FaseModules entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(FaseModules entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(FaseModules entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
