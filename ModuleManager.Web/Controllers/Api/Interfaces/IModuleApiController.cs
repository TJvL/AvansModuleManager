using System.Web.Http;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.Web.ViewModels.RequestViewModels;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IModuleApiController
    {
        ModuleListViewModel GetOverview([FromBody] ArgumentsViewModel value);
        void Delete(Module entity);
        void Create(Module entity);  
    }
}