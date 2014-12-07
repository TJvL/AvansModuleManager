
using System.Collections.Generic;

namespace ModuleManager.DomainDAL.RepositoryInterfaces
{
    public interface IModuleRepository
    {
        //TODO: Toevoegen alle CRUD acties.
        IEnumerable<Module> GetAllModules();
    }
}
