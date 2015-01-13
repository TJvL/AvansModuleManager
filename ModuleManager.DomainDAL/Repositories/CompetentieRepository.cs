using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class CompetentieRepository : IGenericRepository<Competentie>
    {
        public IEnumerable<Competentie> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Competentie select b).ToList();
            }
        }

        public Competentie GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Competentie>().Find(keys));
            }
        }

        public bool Create(Competentie entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Competentie entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Competentie entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}