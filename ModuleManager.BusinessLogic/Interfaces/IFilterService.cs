using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces
{
    public interface IFilterService<T> where T : class
    {
        IEnumerable<T> Filter(IQueryablePack<T> toQuery);
    }
}
