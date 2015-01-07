using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
namespace ModuleManager.DomainDAL.Repositories
{
    public class FaseRepository : IGenericRepository<Fase>
    {
        private readonly ICollection<Fase> _fases;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;
        public FaseRepository()
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
            return (from b in dbContext.Fase select b).ToList();
        }

        public Fase GetOne(string key)
        {
            return (from b in dbContext.Fase where b.Naam.Equals(key) select b).First();
        }

        public bool Create(Fase entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Fase entity)
        {
            dbContext.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Fase entity)
        {
            dbContext.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Modified;
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