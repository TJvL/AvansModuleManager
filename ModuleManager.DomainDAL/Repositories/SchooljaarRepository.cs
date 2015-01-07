using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

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
            return (from b in dbContext.Schooljaar select b).ToList();
        }

        public Schooljaar GetOne(string key)
        {
            return (from b in dbContext.Schooljaar where b.JaarId.Equals(key) select b).First();
        }

        public bool Create(Schooljaar entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Schooljaar entity)
        {
            dbContext.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Schooljaar entity)
        {
            dbContext.Entry<Schooljaar>(entity).State = System.Data.Entity.EntityState.Modified;
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
