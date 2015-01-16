using ModuleManager.DomainDAL;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ModuleTabelViewModel
    {
        public string Onderdeel { get; set; }
        public string Cursuscode { get; set; }
        public string Omschrijving { get; set; }
        public string Contacturen { get; set; }
        public string Werkvormen { get; set; }
        public StudiePunten Studiepunten { get; set; }
    }
}