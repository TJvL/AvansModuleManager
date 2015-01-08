using System.Collections.Generic;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Any and All arguments to filter and sort anything.
    /// </summary>
    public class FilterSorterArguments
    {
        public FilterSorterArguments() 
        {
            SortArguments = new Dictionary<string,bool>();
        }

        public bool IsEmpty
        {
            get
            {
                return (SortArguments.Count == 0) && (ZoektermFilter == null) && (CompetentieFilters == null) &&
                       (CompetentieNiveauFilters == null) && (TagFilters == null) && (LeerlijnFilters == null) &&
                       (BlokFilters == null) && (FaseFilters == null) && (LeerjaarFilter == 0) && (EcFilters == null) && (StatusFilter == null);
            }
        }

        /// <summary>
        /// Bevat kolomnamen voor sorteren, met aflopende prioriteit
        /// </summary>
        /// <remarks>
        /// string SortArgument, boolean Descending.
        /// </remarks>
        public Dictionary<string, bool> SortArguments { get; set; }

        /// <summary>
        /// Algemene zoekterm
        /// </summary>
        public string ZoektermFilter { get; set; }

        /// <summary>
        /// Geselecteerde/mogelijke status om op te filteren
        /// </summary>
        public string StatusFilter { get; set; }
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
        /// Geselecteerde/mogelijke Leerjaar om op te filteren
        /// </summary>
        public int LeerjaarFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke EC(s) om op te filteren
        /// </summary>
        public ICollection<int> EcFilters { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke blok(ken) om op te filteren
        /// </summary>
        public ICollection<int> BlokFilters { get; set; }
    }
}
