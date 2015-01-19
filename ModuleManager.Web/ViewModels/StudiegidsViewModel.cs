using ModuleManager.Web.ViewModels.PartialViewModel;
using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels
{
    // alles lessentabellen van de opleiding
    public class StudiegidsViewModel
    {
        public StudiegidsViewModel()
        {
            Opleidingsfasen = new List<LessenTabelViewModel>();
        }

        public ICollection<LessenTabelViewModel> Opleidingsfasen { get; set; }
    }
}