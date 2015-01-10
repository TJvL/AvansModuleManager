using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces
{
    public interface IExportablePack<T> where T : class
    {
        ExportOptions Options { get; set; }
        IEnumerable<T> ToExport { get; set; }
    }
}
