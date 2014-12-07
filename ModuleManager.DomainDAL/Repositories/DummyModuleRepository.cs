using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using ModuleManager.DomainDAL.RepositoryInterfaces;

namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyModuleRepository : IModuleRepository
    {
        private readonly List<Module> _modules;

        public DummyModuleRepository()
        {
            //TODO: Toevoegen van zinvolle dummy data.

            _modules = new List<Module>();
        }

        public System.Collections.Generic.IEnumerable<Module> GetAllModules()
        {
            return _modules;
        }
    }
}
