using System.Collections.Generic;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface ILeerlijnController
    {
        IEnumerable<Leerlijn> GetAllLeerlijn();
        Leerlijn GetLeerlijn(string naam);
        bool DeleteLeerlijn(Leerlijn leerlijn);
        bool EditLeerlijn(Leerlijn leerlijn);
        bool CreateLeerlijn(Leerlijn leerlijn);  
    }
}