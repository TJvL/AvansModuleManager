using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ModuleManager.Web.ViewModels.EntityViewModel;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ModuleEditOptionsViewModel
    {
        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<CompetentieViewModel> Competenties { get; set; }
        public ICollection<LeerlijnViewModel> Leerlijnen { get; set; }
        public ICollection<WerkvormViewModel> Werkvormen { get; set; }
        public ICollection<NiveauViewModel> Niveaus { get; set; }

        public void Filter(ModuleViewModel vm)
        {
            //for (int i = 0; i < vm.Tag.Count; i++)
            //{
            //    var tags = (from t in Tags where t.Naam == vm.Tag.ElementAt(i).Naam && t.Schooljaar == vm.Tag.ElementAt(i).Schooljaar select t).ToList();

            //    if (tags.Count == 1)
            //    {
            //        if (this.Tags.Remove(tags.First()))
            //        {
            //            --i;
            //        }
            //    }
            //}

            //for (int i = 0; i < vm.ModuleCompetentie.Count; i++)
            //{
            //    var competenties = (from c in Competenties where c.Naam == vm.ModuleCompetentie.ElementAt(i).Competentie.Naam && c.Schooljaar == vm.ModuleCompetentie.ElementAt(i).Competentie.Schooljaar select c).ToList();

            //    if (competenties.Count == 1)
            //    {
            //        if (this.Competenties.Remove(competenties.First()))
            //        {
            //            --i;
            //        }
            //    }
            //}

            //for (int i = 0; i < vm.Leerlijn.Count; i++)
            //{
            //    var leerlijnen = (from l in Leerlijnen where l.Naam == vm.Leerlijn.ElementAt(i).Naam && l.Schooljaar == vm.Leerlijn.ElementAt(i).Schooljaar select l).ToList();

            //    if(leerlijnen.Count == 1)
            //    {
            //        if (this.Leerlijnen.Remove(leerlijnen.First()))
            //        {
            //            --i;
            //        }
            //    }
            //}

            //for (int i = 0; i < vm.ModuleWerkvorm.Count; i++)
            //{
            //    var werkVormen = (from w in Werkvormen where w.Type == vm.ModuleWerkvorm.ElementAt(i).WerkvormType select w).ToList();

            //    if (werkVormen.Count == 1)
            //    {
            //        if (this.Werkvormen.Remove(werkVormen.First()))
            //        {
            //            --i;
            //        }
            //    }
            //}
        }
    }
}