using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels {

    /// <summary>
    /// Deze viewmodel wordt gebruikt voor de Admin/Index-pagina en de Admin/Archive-pagina
    /// </summary>
    public class AdminViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
    }
}