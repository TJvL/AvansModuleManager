using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
namespace ModuleManager.DomainDAL.Repositories.Dummies
{
    public class DummyFaseRepository : IGenericRepository<Fase>
    {
        private readonly ICollection<Fase> _fases;
        public DummyFaseRepository()
        {
            _fases = new Collection<Fase>
			{
				new Fase
				{
				Naam = "Software Ontwikkeling",
				Beschrijving = "Dit is de major Software Onwikkeling, afgekort SO.",
				FaseType = "Major",
				Schooljaar = 1415,
				OpleidingNaam = "Informatica",
				OpleidingSchooljaar = 1415
				},
				new Fase
				{
				Naam = "Business Intelligence",
				Beschrijving = "Dit is de major Business Intelligence, afgekort BI.",
				FaseType = "Major",
				Schooljaar = 1415,
				OpleidingNaam = "Informatica",
				OpleidingSchooljaar = 1415
				},
				new Fase
				{
				Naam = "Software Architecture",
				Beschrijving = "Dit is de minor Software Architecture." +
				"Hierin wordt geleerd hoe je de architectuur van software goed kan opbouwen.",
				FaseType = "Minor",
				Schooljaar = 1415,
				OpleidingNaam = "Informatica",
				OpleidingSchooljaar = 1415
				},
				new Fase
				{
				Naam = "TestFase",
				Beschrijving = "Dit is een testfase.",
				FaseType = "Minor",
				Schooljaar = 1415,
				OpleidingNaam = "Informatica",
				OpleidingSchooljaar = 1415
				}
			};
        }

        public IEnumerable<Fase> GetAll()
        {
            return _fases;
        }

        public Fase GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new System.ArgumentException();

            return (_fases.Where(fase => fase.Naam.Equals(keys[0]))).First();
        }

        public bool Create(Fase entity)
        {
            if (_fases != null)
            {
                _fases.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Fase entity)
        {
            return _fases.Remove(entity);
        }

        public bool Edit(Fase entity)
        {
            Fase oldFase = (_fases.Where(fase => fase.Naam.Equals(entity.Naam))).First();
            if (Delete(oldFase))
            {
                return Create(entity);
            }
            return false;
        }
    }
}