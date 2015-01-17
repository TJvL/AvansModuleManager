using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class ToetsvormRepository : IGenericRepository<Toetsvorm>
    {
        public IEnumerable<Toetsvorm> GetAll()
        {
            using (var context = new DomainContext())
            {
                return (from o in context.Toetsvorm select o).ToList();
            }
        }

        public Toetsvorm GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new ArgumentException("keys");

            using (var context = new DomainContext())
            {
                return (context.Set<Toetsvorm>().Find(keys));
            }
        }

        public bool Create(Toetsvorm entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Toetsvorm entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Toetsvorm entity)
        {
            using (var context = new DomainContext())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
