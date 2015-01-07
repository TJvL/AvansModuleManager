using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories.Dummies
{
    public class DummyBlokRepository : IGenericRepository<Blok>
    {
        private readonly ICollection<Blok> _blokken;

        public DummyBlokRepository()
        {
            _blokken = new List<Blok>
            {
                new Blok
                {
                    BlokId = "1"
                },
                new Blok
                {
                    BlokId = "2"
                },
                new Blok
                {
                    BlokId = "3"
                },
                new Blok
                {
                    BlokId = "4"
                },
                new Blok
                {
                    BlokId = "5"
                }
            };
        }

        public IEnumerable<Blok> GetAll()
        {
            return _blokken;
        }

        public Blok GetOne(string key)
        {
            return (_blokken.Where(blok => blok.BlokId.Equals(key))).First();
        }

        public bool Create(Blok entity)
        {
            if (_blokken == null)
                return false;
            _blokken.Add(entity);
            return true;
        }

        public bool Delete(Blok entity)
        {
            return _blokken.Remove(entity);
        }

        public bool Edit(Blok entity)
        {
            Blok oldBlok = (_blokken.Where(blok => blok.BlokId.Equals(entity.BlokId))).First();
            if (Delete(oldBlok))
            {
                return Create(entity);
            }
            return false;
        }
    }
}
