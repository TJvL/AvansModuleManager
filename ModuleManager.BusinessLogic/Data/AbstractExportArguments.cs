using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    public abstract class AbstractExportArguments
    {
        /// <summary>
        /// Setting this to "true" will override any options you have, and export everything.
        /// </summary>
        public bool ExportAll { get; set; }
    }
}
