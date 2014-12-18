using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces
{
    public interface IFilterSorterService<T> where T:class
    {
        IEnumerable<T> ProcessData(IQueryablePack<T> inputData);
    }
}
