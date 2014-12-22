using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Filters
{
    public class ModulePassiveFilter : IFilter<Module>
    {
        public IQueryable<Module> Filter(IQueryable<Module> toQuery, Arguments args) 
        {
            return toQuery;
        }
    }
}
