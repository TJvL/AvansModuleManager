using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels
{
    public class CheckModulesViewModel
    {
        /// <summary>
        /// Module-informatie zichtbaar in het overview
        /// </summary>
        public ModuleListViewModel ModuleViewModels { get; set; }

        /// <summary>
        /// Gebruikers-informatie die wordt weergegeven in het gebruikersoverview
        /// Bevat gebruikersnaam & gebruikersrol & email
        /// </summary>
        public UserListViewModel Users { get; set; }
    }
}