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
            Onderdelen = new List<OnderdeelTabelViewModel>();
        }

        public string FaseNaam { get; set; }
        public string Blok { get; set; }

        public string Semester
        {
            get
            {
                return "" + Math.Ceiling(Convert.ToInt32(Blok) / 2.0);
            }
        }

        //string[] values = s.Split(',').Select(sValue => sValue.Trim()).ToArray();
        public int TotaleContactUren
        {
            get
            {
                return Onderdelen.SelectMany(src => src.Modules)
                    .Aggregate("", (current, m) => current + (m.Contacturen + "+"))
                    .Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries)
                    .Sum(retValue => Convert.ToInt32(retValue));
            }
        }

        public int TotaleEcs
        {
            get { return (int)Onderdelen.SelectMany(src => src.Modules).SelectMany(src => src.Studiepunten).Sum(src => src.EC); }
        }

        public ICollection<OnderdeelTabelViewModel> Onderdelen { get; set; }
    }
}