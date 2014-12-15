using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface ILeerlijnRepository
    {
        IEnumerable<Leerlijn> GetAllLeerlijnen();
        Leerlijn GetLeerlijn(string naam);
        bool CreateLeerlijn(Leerlijn leerlijn);
        bool DeleteLeerlijn(Leerlijn leerlijn);
        bool EditLeerlijn(Leerlijn leerlijn);
    }
}