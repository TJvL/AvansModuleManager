using System.Collections.Generic;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels {
    public class AdminUserManagementViewModel {

        /// <summary>
        /// Gebruikers-informatie rechtboven van de pagina
        /// Bevat gebruikersnaam & gebruikersrol
        /// </summary>
        public UserViewModel User { get; set; }
        /// <summary>
        /// Gebruikers-informatie die wordt weergegeven in het gebruikersoverview
        /// Bevat gebruikersnaam & gebruikersrol & email
        /// </summary>
        public UserListViewModel Users { get; set; }
    }
}