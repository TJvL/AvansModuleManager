using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels {
    public class HomeIndexViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
        /// <summary>
        /// Bevat populaire tags om weer te geven
        /// </summary>
        public ICollection<Tag> Tags { get; set; }
    }
}