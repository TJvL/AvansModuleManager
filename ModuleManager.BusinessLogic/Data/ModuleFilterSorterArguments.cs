using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Any and All arguments to filter and sort anything.
    /// </summary>
    public class ModuleFilterSorterArguments
    {
        public bool IsEmpty
        {
            get
            {
                return (SortBy == null) && (ZoektermFilter == null) && (CompetentieFilters == null) &&
                       (CompetentieNiveauFilters == null) && (TagFilters == null) && (LeerlijnFilters == null) &&
                       (BlokFilters == null) && (FaseFilters == null) && (LeerjaarFilter == 0) && (ECfilters == null) && (StatusFilter == null);
            }
        }

        /// <summary>
        /// Geeft aan op welk veld gesorteerd meot worden.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Geeft aan of sorting oplopend of aflopen gebeurt. true = desc,  false = asc
        /// </summary>
        public bool SortDesc { get; set; }

        /// <summary>
        /// Geselecteerde/mogelijke competentie(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke competentieniveau(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieNiveauFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke tag(s) om op te filteren
        /// </summary>
        public ICollection<string> TagFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke leerlijn(en) om op te filteren
        /// </summary>
        public ICollection<string> LeerlijnFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke fasenaam(namen) om op te filteren
        /// </summary>
        public ICollection<string> FaseFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke blok(ken) om op te filteren
        /// </summary>
        public ICollection<string> BlokFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke EC(s) om op te filteren
        /// </summary>
        public ICollection<int> ECfilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke status om op te filteren
        /// </summary>
        public string StatusFilter { get; set; }
        /// <summary>
        /// Algemene zoekterm
        /// </summary>
        public string ZoektermFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke Leerjaar om op te filteren
        /// </summary>
        public int LeerjaarFilter { get; set; }
    }
}
