using System.Collections.Generic;
using ModuleManager.DomainDAL;
namespace ModuleManager.Web.ViewModels.PartialViewModel
{

    /// <summary>
    /// Moduleinformatie weergegeven voor de module overview-pagina's
    /// </summary>
    public class ModuleViewModel
    {
        /// <summary>
        /// Onderdeel van de Module/Overview
        /// </summary>
        public char Icon { get; set; }
        public string Naam { get; set; }
        public string CursusCode { get; set; }
        public ICollection<int> Blok { get; set; }
        public int TotalEc { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/CheckModules
        /// </summary>
        public string Status { get; set; }
        public string Verantwoordelijke { get; set; }
        public ICollection<Docent> Docent { get; set; }

        /// <summary>
        /// Onderdeel van de Admin/Curriculum
        /// </summary>
        public ICollection<FaseModules> FaseModules { get; set; } // TODO: uhm help?
    }
}