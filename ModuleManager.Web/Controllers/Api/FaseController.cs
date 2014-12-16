using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class FaseController : ApiController, IFaseController
    {
        private readonly IFaseRepository _faseRepository;

        public FaseController(IFaseRepository faseRepository)
        {
            _faseRepository = faseRepository;
        }

        public IEnumerable<Fase> GetAllFases()
        {
            throw new System.NotImplementedException();
        }

        public Fase GetFase(string naam)
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

        public bool CreateFase(Fase fase)
        {
            throw new System.NotImplementedException();
        }
    }
}
