using System.Linq;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Interfaces;
using System;

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
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Tag select b).ToList();
            }
        }

        public Tag GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Tag>().Find(keys));
            }
        }

        public bool Create(Tag entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Tag entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Tag entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Tag>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}