using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class BlokRepository : IGenericRepository<Blok>
    {
        //private readonly ICollection<Blok> _blokken;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;

        public BlokRepository()
        {
            dbContext = new DomainContext();

            //_blokken = (from b in dbContext.Blok select b).ToList();

            //_blokken = new List<Blok>
            //{
            //    new Blok
            //    {
            //        BlokId = "1"
            //    },
            //    new Blok
            //    {
            //        BlokId = "2"
            //    },
            //    new Blok
            //    {
            //        BlokId = "3"
            //    },
            //    new Blok
            //    {
            //        BlokId = "4"
            //    },
            //    new Blok
            //    {
            //        BlokId = "5"
            //    }
            //};
        }

        public IEnumerable<Blok> GetAll()
        {
            return (from b in dbContext.Blok select b).ToList();
        }

        public Blok GetOne(string key)
        {
            return (from b in dbContext.Blok where b.BlokId.Equals(key) select b).First();
        }

        public bool Create(Blok entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Blok>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Blok entity)
        {
            dbContext.Entry<Blok>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Blok entity)
        {
            dbContext.Entry<Blok>(entity).State = System.Data.Entity.EntityState.Modified;
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
