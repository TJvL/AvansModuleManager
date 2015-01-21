﻿using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels
{
    public class ModuleOverviewViewModel
    {
        /// <summary>
        /// Module-informatie zichtbaar in het overview
        /// </summary>
        public ModuleListViewModel ModuleViewModels { get; set; }
        /// <summary>
        /// Bevat configuratie/argumenten/instellingen voor de filters en de sortering van het moduleoverzicht
        /// </summary>
        public FilterOptionsViewModel FilterOptions { get; set; }
    }
}