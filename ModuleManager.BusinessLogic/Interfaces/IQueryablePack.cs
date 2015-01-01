using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for all Data manipulation in the business-logic.
    /// </summary>
    /// <remarks>
    /// Don't use this thing to implement your own, this interface is to define data structures within this DLL only.
    /// </remarks>
    public interface IQueryablePack<T> where T : class
    {
        /// <summary>
        /// Get Property for Arguments (Always the same format)
        /// </summary>
        Arguments Args { get; }
        /// <summary>
        /// get Property for any Data.
        /// </summary>
        IQueryable<T> Data { get; }
    }
}
