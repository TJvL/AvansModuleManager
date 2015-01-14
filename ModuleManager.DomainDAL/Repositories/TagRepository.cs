using System.Linq;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class TagRepository : IGenericRepository<Tag>
    {
        public IEnumerable<Tag> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from b in context.Tag select b).ToList();
            }
        }

        public Tag GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Tag>().Find(keys));
            }
        }

        public bool Create(Tag entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Tag entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Tag entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}