using System.Collections.Generic;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyCompetentieRepository :ICompetentieRepository
    {

        public IEnumerable<Competentie> GetAllCompetenties()
        {
            throw new System.NotImplementedException();
        }

        public Competentie GetCompetentie(string cursusCode)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateCompetentie(Competentie competentie)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteCompetentie(Competentie competentie)
        {
            throw new System.NotImplementedException();
        }

        public bool EditCompetentie(Competentie competentie)
        {
            throw new System.NotImplementedException();
        }
    }
}