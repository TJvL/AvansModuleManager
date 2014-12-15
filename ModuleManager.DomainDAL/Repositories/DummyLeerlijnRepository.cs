using System.Collections.Generic;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyLeerlijnRepository : ILeerlijnRepository
    {

        public IEnumerable<Leerlijn> GetAllLeerlijnen()
        {
            throw new System.NotImplementedException();
        }

        public Leerlijn GetLeerlijn(string naam)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateLeerlijn(Leerlijn leerlijn)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteLeerlijn(Leerlijn leerlijn)
        {
            throw new System.NotImplementedException();
        }

        public bool EditLeerlijn(Leerlijn leerlijn)
        {
            throw new System.NotImplementedException();
        }
    }
}