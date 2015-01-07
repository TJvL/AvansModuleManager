using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

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
            return (from b in dbContext.Niveau select b).ToList();
        }

        public Niveau GetOne(string key)
        {
            return (from b in dbContext.Niveau where b.ModuleCompetentie.Equals(key) select b).First();
        }

        public bool Create(Niveau entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Niveau entity)
        {
            dbContext.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Niveau entity)
        {
            dbContext.Entry<Niveau>(entity).State = System.Data.Entity.EntityState.Modified;
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
