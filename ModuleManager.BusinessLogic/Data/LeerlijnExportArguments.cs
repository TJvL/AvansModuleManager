using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    public class LeerlijnExportArguments : AbstractExportArguments
    {
        /// <summary>
        /// true if name needs to be exported
        /// </summary>
        public bool ExportNaam { get; set; }
        /// <summary>
        /// true if contained Modules need to be exported
        /// </summary>
        public bool ExportModules { get; set; }
        /// <summary>
        /// true if contained Competences need to be exported
        /// </summary>
        public bool ExportCompetenties { get; set; }
    }
}
