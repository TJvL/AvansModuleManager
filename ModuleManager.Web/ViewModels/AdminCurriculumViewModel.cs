using System.Collections.Generic;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.ViewModels {
    public class AdminCurriculumViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
        /// <summary>
        /// Bevat alle tags om weer te geven
        /// </summary>
        public ICollection<Tag> Tags { get; set; }
        /// <summary>
        /// Bevat alle competenties om weer te geven
        /// </summary>
        public ICollection<Competentie> Competenties { get; set; }
        /// <summary>
        /// Bevat alle leerlijnen om weer te geven
        /// </summary>
        public ICollection<Leerlijn> Leerlijn { get; set; }
        /// <summary>
        /// Module-informatie zichtbaar in het overview
        /// </summary>
        public ModuleListViewModel ModuleViewModels { get; set; }
        /// <summary>
        /// Bevat configuratie/argumenten/instellingen voor de filters en de sortering van het moduleoverzicht
        /// </summary>
        public FilterAndSortingViewModel FilterAndSortingConfig { get; set; }
    }
}