using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
using System;
namespace ModuleManager.DomainDAL.Repositories
{
    public class LeerlijnRepository : IGenericRepository<Leerlijn>
    {
        private readonly ICollection<Leerlijn> _leerlijnen;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;

        public LeerlijnRepository()
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
            using (DomainContext context = new DomainContext())
            {
                return (from b in context.Leerlijn select b).ToList();
            }
        }

        public Leerlijn GetOne(object[] keys)
        {
            if (keys.Length != 2)
                throw new System.ArgumentException();

            using (DomainContext context = new DomainContext())
            {
                return (context.Set<Leerlijn>().Find(keys));
            }
        }

        public bool Create(Leerlijn entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Added;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Delete(Leerlijn entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Deleted;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }

        public bool Edit(Leerlijn entity)
        {
            using (DomainContext context = new DomainContext())
            {
                context.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Modified;
                return Convert.ToBoolean(context.SaveChanges());
            }
        }
    }
}