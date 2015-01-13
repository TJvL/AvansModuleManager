using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;
namespace ModuleManager.DomainDAL.Repositories
{
    public class LeerlijnRepository : IGenericRepository<Leerlijn>
    {
        public IEnumerable<Leerlijn> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Leerlijn select b).ToList();
            }
        }

        public Leerlijn GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new ArgumentException();

            using (var context = new DomainContext())
            {
                return (context.Set<Leerlijn>().Find(keys));
            }
        }

        public bool Create(Leerlijn entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Leerlijn entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Leerlijn entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}