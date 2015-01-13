using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Exporters
{
    /// <summary>
    /// Base interface for anything that exports
    /// </summary>
    /// <typeparam name="T">Anything that you want to be exportable</typeparam>
    public interface IExporter<T> where T : class
    {
        /// <summary>
        /// Export a single element of the input to a section
        /// </summary>
        /// <param name="toExport">Data to get element from</param>
        /// <param name="sect">Section to write to</param>
        /// <returns>Section with appended data</returns>
        Section Export(T toExport, Section sect);
    }
}
