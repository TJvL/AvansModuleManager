using System.Collections.Generic;
namespace ModuleManager.Web.ViewModels.PartialViewModel {

    /// <summary>
    /// Deze klasse heeft twee functies:
    ///     - Doorgeven aan de views, welke filtermogelijkheden er zijn en welke kolommen mogelijk zijn voor weergave
    ///     - Het accepteren van de, door de gebruikers geselecteerde, filters/sorters aan de back-end
    /// </summary>
    public class FilterAndSortingViewModel {

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
        /// Zoekterm om op te filteren
        /// </summary>
        public string Zoekterm { get; set; }
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
        /// <summary>
        /// Bevat kolomnamen voor sorteren, met aflopende prioriteit
        /// </summary>
        public ICollection<string> SortConfig { get; set; }
    }
}