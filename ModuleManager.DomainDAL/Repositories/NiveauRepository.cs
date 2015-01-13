using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class NiveauRepository : IGenericRepository<Niveau>
    {
        private readonly ICollection<Niveau> _niveau;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;

        public NiveauRepository()
        {
            _niveau = new List<Niveau>
            {
                new Niveau
                {
                    Niveau1 = "Beginner"
                },
                new Niveau
                {
                    Niveau1 = "Beoefend"
                },
                new Niveau
                {
                    Niveau1 = "Expert"
                }
            };
        }

        public IEnumerable<Niveau> GetAll()
        {
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Niveau select b).ToList();
            }
        }

        public Niveau GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Niveau>().Find(keys));
            }
        }

        public bool Create(Niveau entity)
        {
            using (DomainContext context = new DomainContext())
            {
                dbContext.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Niveau entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Niveau entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
