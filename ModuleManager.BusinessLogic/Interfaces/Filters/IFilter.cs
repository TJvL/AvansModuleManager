using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Filters
{
    /// <summary>
    /// Base Filter class for EVERYTHING
    /// </summary>
    /// <typeparam name="T">EVERYTHING</typeparam>
    public interface IFilter<T> where T : class 
    {
        /// <summary>
        /// Filter any elements using all arguments
        /// </summary>
        /// <param name="toQuery">Data</param>
        /// <param name="args">Arguments Object</param>
        /// <returns>Queried Data</returns>
        IQueryable<T> Filter(IQueryable<T> toQuery, ModuleFilterSorterArguments args);
    }
}
