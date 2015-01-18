using System.Collections;
using System.Collections.Generic;
using ModuleManager.Web.ViewModels.EntityViewModel;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ModuleEditOptionsViewModel
    {
        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<CompetentieViewModel> Competenties { get; set; }
        public ICollection<LeerlijnViewModel> Leerlijnen { get; set; }
        public ICollection<WerkvormViewModel> Werkvormen { get; set; }
    }
}