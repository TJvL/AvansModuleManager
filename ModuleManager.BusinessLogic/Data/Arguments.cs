using System.Collections.Generic;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Any and All arguments to filter and sort anything.
    /// </summary>
    public class Arguments
    {
        public Arguments() 
        {
            SortFor = new Dictionary<string,bool>();
        }

        public bool IsEmpty
        {
            get
            {
                return (SortFor.Count == 0) && (Zoekterm == null) && (CompetentieFilter == null) &&
                       (CompetentieNiveauFilter == null) && (TagFilter == null) && (LeerlijnFilter == null) &&
                       (Blokken == null) && (FaseNamen == null) && (Leerjaar == 0) && (ECs == null) && (Status1 == null);
            }
        }

        /// <summary>
        /// Bevat kolomnamen voor sorteren, met aflopende prioriteit
        /// </summary>
        /// <remarks>
        /// string SortArgument, boolean Descending.
        /// </remarks>
        public Dictionary<string, bool> SortFor { get; set; }

        /// <summary>
        /// Algemene zoekterm
        /// </summary>
        public string Zoekterm { get; set; }

        /// <summary>
        /// Geselecteerde/mogelijke competentie(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke competentieniveau(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieNiveauFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke tag(s) om op te filteren
        /// </summary>
        public ICollection<string> TagFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke leerlijn(en) om op te filteren
        /// </summary>
        public ICollection<string> LeerlijnFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke blok(ken) om op te filteren
        /// </summary>
        public ICollection<int> Blokken { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke fasenaam(namen) om op te filteren
        /// </summary>
        public ICollection<string> FaseNamen { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke Leerjaar om op te filteren
        /// </summary>
        public int Leerjaar { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke EC(s) om op te filteren
        /// </summary>
        public ICollection<int> ECs { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke status om op te filteren
        /// </summary>
        public string Status1 { get; set; }
    }
}
