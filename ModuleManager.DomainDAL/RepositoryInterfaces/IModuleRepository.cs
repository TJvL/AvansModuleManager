using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface IModuleRepository
    {
        IEnumerable<Module> GetAllModules();
        Module GetModule(string cursusCode);
    }
}