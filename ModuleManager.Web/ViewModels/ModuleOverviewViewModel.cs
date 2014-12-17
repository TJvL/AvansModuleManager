using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels {
    public class ModuleOverviewViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
        /// <summary>
        /// Module-informatie zichtbaar in het overview
        /// </summary>
        public ModuleListViewModel Modules { get; set; }
        /// <summary>
        /// Bevat configuratie/argumenten/instellingen voor de filters en de sortering van het moduleoverzicht
        /// </summary>
        public FilterAndSortingViewModel FilterAndSortingConfig { get; set; }

    }
}