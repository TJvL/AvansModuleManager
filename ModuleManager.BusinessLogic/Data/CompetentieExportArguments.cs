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
        /// <summary>
        /// true if code/id needs to be exported
        /// </summary>
        public bool ExportCode { get; set; }

        /// <summary>
        /// true if description needs to be exported
        /// </summary>
        public bool ExportBeschrijving { get; set; }
    }
}
