using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface ICompetentieRepository
    {
        IEnumerable<Competentie> GetAllCompetenties();
        Competentie GetCompetentie(string compCode);
        bool CreateCompetentie(Competentie competentie);
        bool DeleteCompetentie(Competentie competentie);
        bool EditCompetentie(Competentie competentie);
    }
}