using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;

namespace ModuleManager.DomainDAL.Repositories
{
    public class StatusRepository : IGenericRepository<Status>
    {
        private readonly ICollection<Status> _status;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;
        public StatusRepository()
        {
            _status = new List<Status>
            {
                new Status
                {
                    Status1 = "Incompleet"
                },
                new Status
                {
                    Status1 = "Nieuw"
                },
                new Status
                {
                    Status1 = "Compleet(gecontroleerd)"
                },
                new Status
                {
                    Status1 = "Compleet(ongecontroleerd)"
                }
            };
        }

        public IEnumerable<Status> GetAll()
        {
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Status select b).ToList();
            }
        }

        public Status GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Status>().Find(keys));
            }
        }

        public bool Create(Status entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Status>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Status entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Status>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Status entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Status>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}
