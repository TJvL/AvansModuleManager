using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyNiveauRepository : IGenericRepository<Niveau>
    {
        private readonly ICollection<Niveau> _niveau;

        public DummyNiveauRepository()
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
            return _niveau;
        }

        public Niveau GetOne(string key)
        {
            return (_niveau.Where(niveau => niveau.Niveau1.Equals(key))).First();
        }

        public bool Create(Niveau entity)
        {
            if (_niveau != null)
            {
                _niveau.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Niveau entity)
        {
            return _niveau.Remove(entity);
        }

        public bool Edit(Niveau entity)
        {
            Niveau oldNiveau = (_niveau.Where(niveau => niveau.Niveau1.Equals(entity.Niveau1))).First();
            if (Delete(oldNiveau))
            {
                return Create(entity);
            }
            return false;
        }
    }
}
