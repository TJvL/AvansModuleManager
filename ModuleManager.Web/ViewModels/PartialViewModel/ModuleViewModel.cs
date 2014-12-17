using ModuleManager.DomainDAL;
namespace ModuleManager.Web.ViewModels.PartialViewModel {

    /// <summary>
    /// Moduleinformatie weergegeven voor de module overview-pagina's
    /// </summary>
    public class ModuleViewModel {
        /// <summary>
        /// /// Onderdeel van de Module/Overview
        /// </summary>
        public string Naam { get; set; }
        public string CursusCode { get; set; }
        public int Blok { get; set; }
        public StudiePunten StudiePunten { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/CheckModules
        /// </summary>
        public string Status { get; set; }
        public string Verantwoordelijke { get; set; }
        public string VakDocenten { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/Curriculum
        /// </summary>
        public Fase Fase { get; set; }
    }
}