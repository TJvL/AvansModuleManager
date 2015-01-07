using System.Linq;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class TagRepository : IGenericRepository<Tag>
    {
        private readonly ICollection<Tag> _tags;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;
        public TagRepository()
        {
            _tags = new List<Tag>
            {
                new Tag
                {
                    Naam = "Big Data",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "Tag1",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "Java",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "UML",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "Massive Data",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "Algoritmiek",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "C#",
                    Schooljaar = 1415
                },
                new Tag
                {
                    Naam = "nested for-loops",
                    Schooljaar = 1415
                }
            };
        }
        public IEnumerable<Tag> GetAll()
        {
            return (from b in dbContext.Tag select b).ToList();
        }

        public Tag GetOne(string key)
        {
            return (from b in dbContext.Tag where b.Naam.Equals(key) select b).First();
        }

        public bool Create(Tag entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Tag entity)
        {
            dbContext.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Tag entity)
        {
            dbContext.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Modified;
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