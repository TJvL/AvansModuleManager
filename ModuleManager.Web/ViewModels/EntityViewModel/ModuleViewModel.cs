using System.Collections.Generic;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.Web.ViewModels.EntityViewModel
{
    public class ModuleViewModel
    {
        public string CursusCode { get; set; }
        public string Schooljaar { get; set; }
        public string Beschrijving { get; set; }
        public string Naam { get; set; }
        public string Verantwoordelijke { get; set; }
        public string Status { get; set; }
        public string OnderdeelCode { get; set; }
        public string Icon { get; set; }

        public ICollection<ModuleCompetentieViewModel> ModuleCompetentie { get; set; }
        public ICollection<StudiePuntenViewModel> StudiePunten { get; set; }
        public ICollection<FaseModulesViewModel> FaseModules { get; set; }
        public ICollection<StudieBelastingViewModel> StudieBelasting { get; set; }
        public ICollection<ModuleWerkvormViewModel> ModuleWerkvorm { get; set; }
        public ICollection<WeekplanningViewModel> Weekplanning { get; set; }
        public ICollection<BeoordelingenViewModel> Beoordelingen { get; set; }
        public ICollection<LeermiddelenViewModel> Leermiddelen { get; set; }
        public ICollection<LeerdoelenViewModel> Leerdoelen { get; set; }
        public ICollection<DocentViewModel> Docent { get; set; }
        public ICollection<LeerlijnViewModel> Leerlijn { get; set; }
        public ICollection<TagViewModel> Tag { get; set; }
        public ICollection<ModuleVoorkennisViewModel> Module2 { get; set; }
    }
}