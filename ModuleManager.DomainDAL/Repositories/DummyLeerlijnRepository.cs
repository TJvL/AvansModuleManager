using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyLeerlijnRepository : IGenericRepository<Leerlijn>
    {
        private readonly ICollection<Leerlijn> _leerlijnen;

        public DummyLeerlijnRepository()
        {
            _leerlijnen = new List<Leerlijn>
			{
				new Leerlijn
				{
					Naam = "Algoritmiek",
					Schooljaar = 1415
				},
				new Leerlijn
				{
					Naam = "Design Principles",
					Schooljaar = 1415
				},
				new Leerlijn
				{
					Naam = "Databases",
					Schooljaar = 1415
				},
				new Leerlijn
				{
					Naam = "Programmeren",
					Schooljaar = 1415
				},
				new Leerlijn
				{
					Naam = "Console-programmas",
					Schooljaar = 1415
				}
			};
        }
        public IEnumerable<Leerlijn> GetAll()
        {
            return _leerlijnen;
        }

        public Leerlijn GetOne(string key)
        {
            return (_leerlijnen.Where(leerlijn => leerlijn.Naam.Equals(key))).First();
        }

        public bool Create(Leerlijn entity)
        {
            if (_leerlijnen != null)
            {
                _leerlijnen.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Leerlijn entity)
        {
            return _leerlijnen.Remove(entity);
        }

        public bool Edit(Leerlijn entity)
        {
            Leerlijn oldComp = (_leerlijnen.Where(leerlijn => leerlijn.Naam.Equals(entity.Naam))).First();
            if (Delete(oldComp))
            {
                return Create(entity);
            }
            return false;
        }
    }
}