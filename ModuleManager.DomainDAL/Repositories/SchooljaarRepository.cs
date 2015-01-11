using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class SchooljaarRepository : IGenericRepository<Schooljaar>
    {
        private readonly ICollection<Schooljaar> _schooljaar;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;

        public SchooljaarRepository()
        {
            _schooljaar = new List<Schooljaar>
            {
                new Schooljaar
                {
                    JaarId = 1415
                },
                new Schooljaar
                {
                    JaarId = 1516
                }
            };
        }

        public IEnumerable<Schooljaar> GetAll()
        {
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Schooljaar select b).ToList();
            }
        }

        public Schooljaar GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Schooljaar>().Find(keys));
            }
        }

        public bool Create(Schooljaar entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Schooljaar entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Schooljaar entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
