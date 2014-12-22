using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Filters;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    public class ModuleFilterService : IFilterService<Module>
    {
        IFilter<Module> moduleFilterStrategy;

        public ModuleFilterService() 
        {
            moduleFilterStrategy = new ModulePassiveFilter();

        }

        public IEnumerable<Module> Filter(IQueryablePack<Module> qPack)
        {
            return moduleFilterStrategy.Filter(qPack.Data, qPack.Args);
        }
    }
}
