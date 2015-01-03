using ModuleManager.BusinessLogic.Interfaces.Sorters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Sorters
{
    public abstract class ModuleBaseSorter : ISorter<Module>
    {
        ISorter<Module> parent;

        public ModuleBaseSorter(ISorter<Module> parent) 
        {
            this.parent = parent;
        }

        public IQueryable<Module> Sort(IQueryable<Module> toSort, Data.Arguments args)
        {
            throw new NotImplementedException();
        }
    }
}
