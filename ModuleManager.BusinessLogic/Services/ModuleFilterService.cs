using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces;
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
        public IEnumerable<Module> Filter(IQueryablePack<Module> toQuery)
        {
            throw new NotImplementedException();
        }
    }
}
