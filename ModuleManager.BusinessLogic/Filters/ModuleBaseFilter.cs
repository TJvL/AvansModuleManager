using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Filters
{
    public abstract class ModuleBaseFilter : IFilter<Module>
    {
        IFilter<Module> parent;

        public ModuleBaseFilter(IFilter<Module> parent) 
        {
            this.parent = parent;
        }

        public IQueryable<Module> Filter(IQueryable<Module> toQuery, Arguments args)
        {
            return parent.Filter(toQuery, args);
        }
    }
}
