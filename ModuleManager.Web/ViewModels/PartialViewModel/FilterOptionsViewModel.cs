using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{

    /// <summary>
    /// Bevat informatie over de filters zodat de betreffende view weet welke filter mogelijkheden een bepaald overzicht heeft
    /// </summary>
    /// <remarks>Als een property null is zal dit geen filter optie zijn voor het betreffende overzicht.</remarks>
    public class FilterOptionsViewModel
    {
        /// <summary>
        /// Mogelijke competentie(s) om op te filteren
        /// </summary>
        public IEnumerable<string> CompetentieFilter { get; set; }
        /// <summary>
        /// Mogelijke competentieniveau(s) om op te filteren
        /// </summary>
        public IEnumerable<string> CompetentieNiveauFilter { get; set; }
        /// <summary>
        /// Mogelijke tag(s) om op te filteren
        /// </summary>
        public IEnumerable<string> TagFilter { get; set; }
        /// <summary>
        /// Mogelijke leerlijn(en) om op te filteren
        /// </summary>
        public IEnumerable<string> LeerlijnFilter { get; set; }
        /// <summary>
        /// Mogelijke fasenaam(namen) om op te filteren
        /// </summary>
        public IEnumerable<string> FaseNamen { get; set; }
        /// <summary>
        /// Mogelijke status(en) om op te filteren
        /// </summary>
        public IEnumerable<string> Status1 { get; set; }
        /// <summary>
        /// Mogelijke blok(ken) om op te filteren
        /// </summary>
        public IEnumerable<int> Blokken { get; set; }
        /// <summary>
        /// Mogelijke Leerjaar(jaren) om op te filteren
        /// </summary>
        public IEnumerable<int> Leerjaren { get; set; }
        /// <summary>
        /// Mogelijke EC(s) om op te filteren
        /// </summary>
        public IEnumerable<double> ECs { get; set; }
    }
}