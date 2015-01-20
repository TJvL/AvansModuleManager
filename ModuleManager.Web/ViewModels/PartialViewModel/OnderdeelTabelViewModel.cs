using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class OnderdeelTabelViewModel
    {
        public OnderdeelTabelViewModel()
        {
            Modules = new List<ModuleTabelViewModel>();
        }

        public string Onderdeel { get; set; }
        public ICollection<ModuleTabelViewModel> Modules { get; set; }
    }
}