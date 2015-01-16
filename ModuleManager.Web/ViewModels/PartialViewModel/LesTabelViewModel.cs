using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class LesTabelViewModel
    {
        public string FaseType { get; set; }
        public string FaseNaam { get; set; }
        public string Blok { get; set; }

        public string Semester
        {
            get
            {
                return Blok;
            }
        }

        public ICollection<ModuleTabelViewModel> Modules { get; set; }
    }
}