using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Filters
{
    public interface IFilter<T> where T : class 
    {
        IQueryable<T> Filter(IQueryable<T> toQuery, Arguments args);
    }
}
