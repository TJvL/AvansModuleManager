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
    public interface IQueryablePack
    {
        /// <summary>
        /// Get the arguments.
        /// </summary>
        /// <returns>the relevant arguments object</returns>
        Arguments GetArguments();
        /// <summary>
        /// Set the arguments
        /// </summary>
        /// <param name="args">The relevant arguments object</param>
        void SetArguments(Arguments args);
        
        /// <summary>
        /// Get the data to use the arguments with.
        /// </summary>
        /// <returns>A queryable of elements</returns>
        IQueryable GetData();
        /// <summary>
        /// Set the data to pass along.
        /// </summary>
        /// <param name="data">Queryable of elements to query</param>
        void SetData(IQueryable data);
    }
}
