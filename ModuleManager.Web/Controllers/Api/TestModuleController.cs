using System.Web.Http;
using System.Web.Http.ModelBinding;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.Web.Controllers.Api.Interfaces;
using ModuleManager.Web.DataTablesMapping;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.Controllers.Api
{
    public class TestModuleController : ApiController, IModuleApiController
    {
        [HttpPost, Route("api/Module/GetOverview")]
        public ModuleListViewModel GetOverview([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            return null;
        }

        public string ExportOverview(ExportViewModel arguments)
        {
            throw new System.NotImplementedException();
        }

        public Module GetOne(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Module entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Module entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Module entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
