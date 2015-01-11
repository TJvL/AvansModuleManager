using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;
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
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Fase select b).ToList();
            }
        }

        public Fase GetOne(object[] keys)
        {
            if (keys.Length != 4)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Fase>().Find(keys));
            }
        }

        public bool Create(Fase entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Fase entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Fase entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Fase>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}