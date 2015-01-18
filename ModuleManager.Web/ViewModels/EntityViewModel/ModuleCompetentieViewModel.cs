using ModuleManager.DomainDAL;

namespace ModuleManager.Web.ViewModels.EntityViewModel
{
    public class ModuleCompetentieViewModel
    {
        public string CursusCode { get; set; }
        public string Schooljaar { get; set; }
        public string CompetentieCode { get; set; }
        public string CompetentieSchooljaar { get; set; }
        public string Niveau { get; set; }

        public CompetentieViewModel Competentie { get; set; }
    }
}