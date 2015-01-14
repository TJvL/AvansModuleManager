using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.RequestViewModels
{
    public class Filter
    {        
        public ICollection<string> Competenties { get; set; }
        public ICollection<string> Leerlijnen { get; set; }
        public ICollection<string> Fases { get; set; }
        public ICollection<string> Blokken { get; set; }
        public ICollection<string> Tags { get; set; }
        public string Zoekterm { get; set; }
        public string Leerjaar { get; set; }
        public string Ec { get; set; }
    }
}