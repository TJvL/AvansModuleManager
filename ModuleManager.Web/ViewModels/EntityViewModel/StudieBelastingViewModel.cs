using System;

namespace ModuleManager.Web.ViewModels.EntityViewModel
{
    public class StudieBelastingViewModel
    {
        public string CursusCode { get; set; }
        public string Schooljaar { get; set; }
        public string Activiteit { get; set; }
        public Nullable<int> ContactUren { get; set; }
        public string Duur { get; set; }
        public string Frequentie { get; set; }
        public int SBU { get; set; } 
    }
}