﻿using System.Collections.Generic;
using ModuleManager.Web.ViewModels.PartialViewModel;
using ModuleManager.DomainDAL;


namespace ModuleManager.Web.ViewModels
{
    public class AdminCurriculumViewModel
    {
        /// <summary>
        /// Bevat alle tags om weer te geven
        /// </summary>
        public IEnumerable<Tag> Tags { get; set; }
        /// <summary>
        /// Bevat alle competenties om weer te geven
        /// </summary>
        public IEnumerable<Competentie> Competenties { get; set; }
        /// <summary>
        /// Bevat alle leerlijnen om weer te geven
        /// </summary>
        public IEnumerable<Leerlijn> Leerlijn { get; set; }
        /// <summary>
        /// Bevat alle fases om weer te geven
        /// </summary>
        public IEnumerable<Fase> Fases { get; set; }
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