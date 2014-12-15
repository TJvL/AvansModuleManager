using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface IFaseRepository
    {
        IEnumerable<Fase> GetAllFases();
        Fase GetFase(string naam);
        bool CreateFase(Fase fase);
        bool DeleteFase(Fase fase);
        bool EditFase(Fase fase);
    }
}