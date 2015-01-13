using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;

namespace ModuleManager.DomainDAL.Repositories.Dummies
{
    public class DummySchooljaarRepository : IGenericRepository<Schooljaar>
    {
        private readonly ICollection<Schooljaar> _schooljaar;

        public DummySchooljaarRepository()
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
            return _schooljaar;
        }

        public Schooljaar GetOne(object[] keys)
        {
            if (keys.Length != 1)
                throw new System.ArgumentException();

            return (_schooljaar.Where(jaar => jaar.JaarId.Equals(int.Parse(keys[0].ToString())))).First();
        }

        public bool Create(Schooljaar entity)
        {
            if (_schooljaar == null)
                return false;
            _schooljaar.Add(entity);
            return true;
        }

        public bool Delete(Schooljaar entity)
        {
            return _schooljaar.Remove(entity);
        }

        public bool Edit(Schooljaar entity)
        {
            Schooljaar oldSchooljaar = (_schooljaar.Where(jaar => jaar.JaarId.Equals(entity.JaarId))).First();
            if (Delete(oldSchooljaar))
            {
                return Create(entity);
            }
            return false;
        }
    }
}
