using System.Collections.Generic;
using System.Web.Http;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.RepositoryInterfaces;
using ModuleManager.Web.Controllers.Api.Interfaces;

namespace ModuleManager.Web.Controllers.Api
{
    public class LeerlijnController : ApiController, ILeerlijnController
    {
        private readonly ILeerlijnRepository _leerlijnRepository;

        public LeerlijnController(ILeerlijnRepository leerlijnRepository)
        {
            _leerlijnRepository = leerlijnRepository;
        }

        public IEnumerable<Leerlijn> GetAllLeerlijn()
        {
            throw new System.NotImplementedException();
        }

        public Leerlijn GetLeerlijn(string naam)
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

        public bool CreateLeerlijn(Leerlijn leerlijn)
        {
            throw new System.NotImplementedException();
        }
    }
}
