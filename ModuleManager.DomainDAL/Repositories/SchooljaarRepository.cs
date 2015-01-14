using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class SchooljaarRepository : IGenericRepository<Schooljaar>
    {
        public IEnumerable<Schooljaar> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Schooljaar select b).ToList();
            }
        }

        public Schooljaar GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Schooljaar>().Find(keys));
            }
        }

        public bool Create(Schooljaar entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Schooljaar entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Schooljaar entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
