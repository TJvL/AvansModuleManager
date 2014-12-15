using System.Collections.Generic;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyFaseRepository : IFaseRepository
    {

        public IEnumerable<Fase> GetAllFases()
        {
            throw new System.NotImplementedException();
        }

        public Fase GetFase(string naam)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateFase(Fase fase)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteFase(Fase fase)
        {
            throw new System.NotImplementedException();
        }

        public bool EditFase(Fase fase)
        {
            throw new System.NotImplementedException();
        }
    }
}