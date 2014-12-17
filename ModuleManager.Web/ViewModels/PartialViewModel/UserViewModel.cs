namespace ModuleManager.Web.ViewModels.PartialViewModel {

    /// <summary>
    /// Onderdeel van alle views behalve de Home/Login-View & de Home/Index-View
    /// </summary>
    public class UserViewModel {

        /// <summary>
        /// Bevat informatie die rechtsboven in de view wordt weergegeven als iemand is ingelogd
        /// </summary>
        public string Username { get; set; }

        public string UserRole { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/Usermanagement-View
        /// Bevat extra informatie die moet worden weergegeven bij de gebruikers-management
        /// </summary>
        public string UserEmail { get; set; }
    }
}