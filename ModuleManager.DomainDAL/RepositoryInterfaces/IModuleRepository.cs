using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface IModuleRepository
    {
        IEnumerable<Module> GetAllModules();
        Module GetModule(string cursusCode);
        bool CreateModule(Module module);
        bool DeleteModule(Module module);
        bool EditModule(Module module);
    }
}