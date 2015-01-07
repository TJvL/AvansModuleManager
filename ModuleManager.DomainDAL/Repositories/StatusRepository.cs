using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

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
            return (from b in dbContext.Status select b).ToList();
        }

        public Status GetOne(string key)
        {
            return (from b in dbContext.Status where b.Module.Equals(key) select b).First();
        }

        public bool Create(Status entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Status>(entity).State = System.Data.Entity.EntityState.Added;
            int changesCount = dbContext.SaveChanges();

            if (changesCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Status entity)
        {
            dbContext.Entry<Status>(entity).State = System.Data.Entity.EntityState.Deleted;
            int changes = dbContext.SaveChanges();

            if (changes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(Status entity)
        {
            dbContext.Entry<Status>(entity).State = System.Data.Entity.EntityState.Modified;
            int changes = dbContext.SaveChanges();

            if (changes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
