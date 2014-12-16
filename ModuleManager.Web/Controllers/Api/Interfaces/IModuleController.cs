using System.Collections.Generic;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.Controllers.Api.Interfaces
{
    public interface IModuleController
    {
        IEnumerable<Module> GetAllModules();
        Module GetModule(string cursusCode);
        bool DeleteModule(Module module);
        bool EditModule(Module module);
        bool CreateModule(Module module); 
    }
}