using ModuleManager.DomainDAL;
using ModuleManager.Web.ViewModels.PartialViewModel;
using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels {
    public class HomeIndexViewModel {

        /// <summary>
        /// Bevat populaire tags om weer te geven
        /// </summary>
        public ICollection<Tag> PopulairTags { get; set; }
    }
}