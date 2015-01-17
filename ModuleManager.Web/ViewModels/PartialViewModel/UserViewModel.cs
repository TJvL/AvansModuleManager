namespace ModuleManager.Web.ViewModels.PartialViewModel
{

    /// <summary>
    /// Onderdeel van alle views behalve de Home/Login-View & de Home/Index-View
    /// </summary>
    public class UserViewModel
    {
        public string Naam { get; set; }

        public string GebruikersNaam { get; set; }

        public string SysteemRol { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/Usermanagement-View
        /// Bevat extra informatie die moet worden weergegeven bij de gebruikers-management
        /// </summary>
        public string Email { get; set; }
    }
}