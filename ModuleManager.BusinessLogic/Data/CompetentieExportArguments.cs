using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    public class CompetentieExportArguments : AbstractExportArguments
    {
        /// <summary>
        /// true if name needs to be exported
        /// </summary>
        public bool ExportNaam { get; set; }
    }
}
