using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    public class ExportOptions
    {
        /// <summary>
        /// Setting this to "true" will override any options you have, and export everything.
        /// </summary>
        public bool ExportAll { get; set; }
        public bool ExportCursusCode { get; set; }
        public bool ExportNaam { get; set; }
        public bool ExportBeschrijving { get; set; }
        public bool ExportAlgInfo { get; set; }
        public bool ExportStudieBelasting { get; set; }
        public bool ExportOrganisatie { get; set; }
        public bool ExportWeekplanning { get; set; }
        public bool ExportBeoordeling { get; set; }
        public bool ExportLeermiddelen { get; set; }
        public bool ExportLeerdoelen { get; set; }
        public bool ExportCompetenties { get; set; }
        public bool ExportLeerlijnen { get; set; }
        public bool ExportTags { get; set; }
    }
}
