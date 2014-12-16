using System.Collections.Generic;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IFaseController
    {
        IEnumerable<Fase> GetAllFases();
        Fase GetFase(string naam);
        bool DeleteFase(Fase fase);
        bool EditFase(Fase fase);
        bool CreateFase(Fase fase);
    }
}