using System;
using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class FaseTypeRepository : IGenericRepository<FaseType>
    {
        public IEnumerable<FaseType> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.FaseType select b).ToList();
            }
        }

        public FaseType GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException();

            using (var context = new DomainContext())
            {
                return (context.Set<FaseType>().Find(keys));
            }
        }

        public bool Create(FaseType entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(FaseType entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(FaseType entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
