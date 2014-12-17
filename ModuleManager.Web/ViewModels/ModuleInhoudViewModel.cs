using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels {

    /// <summary>
    /// Deze viewmodel wordt gebruikt voor de Module/Details-pagina en de Module/Edit-pagina
    /// </summary>
    public class ModuleInhoudViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
        /// <summary>
        /// Module-informatie voor de view
        /// </summary>
        public Module Module { get; set; }
    }
}