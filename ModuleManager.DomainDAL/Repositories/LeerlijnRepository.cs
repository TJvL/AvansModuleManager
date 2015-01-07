using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
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
            return (from b in dbContext.Leerlijn select b).ToList();
        }

        public Leerlijn GetOne(string key)
        {
            return (from b in dbContext.Leerlijn where b.Naam.Equals(key) select b).First();
        }

        public bool Create(Leerlijn entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Added;
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

        public bool Delete(Leerlijn entity)
        {
            dbContext.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Deleted;
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

        public bool Edit(Leerlijn entity)
        {
            dbContext.Entry<Leerlijn>(entity).State = System.Data.Entity.EntityState.Modified;
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