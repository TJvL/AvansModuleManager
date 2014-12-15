using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.DataModel.ModuleInfo {
    public class ModuleInfo {

        // FaseModule.cs
        public string FaseNaam { get; set; }
        public string ModuleCursusCode { get; set; }
        public string Blok { get; set; }

        // Module.cs
        public string CursusCode { get; set; }
        public DateTime Schooljaar { get; set; }
        public string Beschrijving { get; set; }
        public string Naam { get; set; }
        public string Leedoelen { get; set; }
        public string Beoordelingen { get; set; }
        public string Weekplanning { get; set; }
        public string Organisatie { get; set; }
        public string Werkvorm { get; set; }
        public string Leermiddelen { get; set; }
        public string Verantwoordelijkheid { get; set; }
        public string Status { get; set; }
        public string VoorkennisVereistVan { get; set; }
        public string GerelateerdeModules { get; set; }
        //
        public WeekPlanning WeekPlanning { get; set; }
        //
        public ICollection<string> Leerlijn { get; set; }
        public ICollection<string> Tag { get; set; }
        public ICollection<CompetentieInfo> Competenties { get; set; }
        public ICollection<StudiePunten> StudiePunten { get; set; }
        public ICollection<StudieBelasting> StudieBelasting { get; set; }
    }
}