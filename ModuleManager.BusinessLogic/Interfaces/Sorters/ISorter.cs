using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Sorters
{
    /// <summary>
    /// Base sorter class for EVERYTHING
    /// </summary>
    /// <typeparam name="T">EVERYTHING</typeparam>
    public interface ISorter<T> where T : class
    {
        /// <summary>
        /// Sort all elements using all arguments
        /// </summary>
        /// <param name="toSort">Data</param>
        /// <param name="args">Arguments object</param>
        /// <returns>Sorted Data</returns>
        IQueryable<T> Sort(IQueryable<T> toSort, FilterSorterArguments args);
    }
}
