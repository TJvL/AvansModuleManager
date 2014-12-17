using System.Collections.Generic;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IModuleApiController
    {
        IEnumerable<Module> GetOverview(string argument);
        string ExportOverview(string argument);
        Module GetOne(string key);
        bool Delete(Module entity);
        bool Edit(Module entity);
        bool Create(Module entity);  
    }
}