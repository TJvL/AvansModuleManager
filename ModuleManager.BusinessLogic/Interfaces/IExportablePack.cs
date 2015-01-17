using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces
{
    /// <summary>
    /// A pack containing data for exporting
    /// </summary>
    /// <typeparam name="T">The data type to export</typeparam>
    public interface IExportablePack<T> where T : class
    {
        /// <summary>
        /// The options object that will tell what to export
        /// </summary>
        AbstractExportArguments Options { get; set; }
        /// <summary>
        /// The data from which there will be exported
        /// </summary>
        IEnumerable<T> ToExport { get; set; }
    }
}
