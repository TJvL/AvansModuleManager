using System.Linq;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories.Dummies
{
    public class DummyTagRepository : IGenericRepository<Tag>
    {
        private readonly ICollection<Tag> _tags;
        public DummyTagRepository()
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
            return _tags;
        }
        public Tag GetOne(string key)
        {
            return (_tags.Where(tag => tag.Naam.Equals(key))).First();
        }
        public bool Create(Tag entity)
        {
            if (_tags != null)
            {
                _tags.Add(entity);
                return true;
            }
            return false;
        }
        public bool Delete(Tag entity)
        {
            return _tags.Remove(entity);
        }
        public bool Edit(Tag entity)
        {
            Tag oldTag = (_tags.Where(tag => tag.Naam.Equals(entity.Naam))).First();
            if (Delete(oldTag))
            {
                return Create(entity);
            }
            return false;
        }
    }
}