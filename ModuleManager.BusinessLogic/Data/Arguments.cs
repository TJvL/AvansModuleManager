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
    public class Arguments
    {
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
        public int Leerjaren { get; set; }
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
