using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    // één lessentabel
    public class LesTabelViewModel
    {
        public LesTabelViewModel()
        {
            Modules = new List<ModuleTabelViewModel>();
        }

        public string FaseNaam { get; set; }
        public string Blok { get; set; }

        public string Semester
        {
            get
            {
                return Blok;
            }
        }

        //string[] values = s.Split(',').Select(sValue => sValue.Trim()).ToArray();
        public int TotaleContactUren
        {
            get
            {
                return Modules
                    .Aggregate("", (current, m) => current + (m.Contacturen + "+"))
                    .Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries)
                    .Sum(retValue => Convert.ToInt32(retValue));
            }
        }

        public int TotaleEcs
        {
            get { return (int)Modules.SelectMany(src => src.Studiepunten).Sum(src => src.EC); }
        }

        public ICollection<ModuleTabelViewModel> Modules { get; set; }
    }
}