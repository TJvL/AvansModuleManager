using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;
namespace ModuleManager.DomainDAL.Repositories
{
    public class ModuleRepository : IGenericRepository<Module>
    {
        public IEnumerable<Module> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Module select b).ToList();
            }
        }

        public Module GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new ArgumentException();

            using (var context = new DomainContext())
            {
                return (context.Set<Module>().Find(keys));
            }
        }

        public bool Create(Module entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Module entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Module entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}