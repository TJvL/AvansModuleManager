using ModuleManager.DomainDAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    /// <summary>
    /// Deze klasse heeft twee functies:
    ///     - Doorgeven aan de views, welke filtermogelijkheden er zijn en welke kolommen mogelijk zijn voor weergave
    ///     - Het accepteren van de, door de gebruikers geselecteerde, filters/sorters aan de back-end
    /// </summary>
    public class FilterOptionsViewModel
    {

        public void AddCompetenties(IEnumerable<Competentie> competentieList)
        {
            CompetentieFilter = competentieList
                .Select(comp => comp.Naam)
                .ToList();
        }
        public void AddCompetentieNiveaus(IEnumerable<Niveau> niveauList)
        {
            CompetentieNiveauFilter = niveauList
                .Select(niveau => niveau.Niveau1)
                .ToList();
        }
        public void AddTags(IEnumerable<Tag> tagList)
        {
            TagFilter = tagList
                .Select(tag => tag.Naam)
                .ToList();
        }
        public void AddLeerlijnen(IEnumerable<Leerlijn> leerlijnenList)
        {
            LeerlijnFilter = leerlijnenList
                .Select(comp => comp.Naam)
                .ToList();
        }

        public void AddBlokken(IEnumerable<FaseModules> faseModuleList)
        {
            Blokken = faseModuleList
                .Select(faseModule => int.Parse(faseModule.Blok))
                .ToList();
        }

        public void AddFases(IEnumerable<Fase> faseList) // Zie property 'FaseNamen'
        {
            FaseNamen = faseList
                .DistinctBy(fase => fase.FaseType)
                .Select(fase => fase.FaseType)
                .ToList();

            //FaseNamen = faseList
            //    .Select(fase => fase.Naam)
            //    .ToList();
        }

        public void AddECs(IEnumerable<Module> moduleList) // Zie property 'ECs'
        {
            ECs = moduleList
                .DistinctBy(module => module.StudiePunten
                    .Select(punten => punten.EC)
                    .Count()
                )
                .Select(module => module.StudiePunten
                    .Select(punten => punten.EC)
                    .Count()
                )
                .ToList();
        }

        public void AddStatuses(IEnumerable<Status> statusList) // Zie property 'Status1'
        {
            Status1 = statusList
                .Select(status => status.Status1)
                .First();
            //.ToList(); // vervangen met .First(); dit kan nu niet omdat 'Status1' een string is i.p.v. IEnumerable<string>
        }

        /// <summary>
        /// Geselecteerde/mogelijke competentie(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke competentieniveau(s) om op te filteren
        /// </summary>
        public ICollection<string> CompetentieNiveauFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke tag(s) om op te filteren
        /// </summary>
        public ICollection<string> TagFilter { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke leerlijn(en) om op te filteren
        /// </summary>
        public ICollection<string> LeerlijnFilter { get; set; }
        /// <summary>
        /// Zoekterm om op te filteren
        /// </summary>
        public string Zoekterm { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke blok(ken) om op te filteren
        /// </summary>
        public ICollection<int> Blokken { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke fasenaam(namen) om op te filteren
        /// </summary>
        public ICollection<string> FaseNamen { get; set; } // is dit namen (vb. softwareontwikkeling, businessintelligence, software architectuur) of types (vb. minor, major, prop)
        /// <summary>
        /// Geselecteerde/mogelijke Leerjaar om op te filteren
        /// </summary>
        public int Leerjaren { get; set; } // hoe wordt dit meegegeven?
        /// <summary>
        /// Geselecteerde/mogelijke EC(s) om op te filteren
        /// </summary>
        public ICollection<int> ECs { get; set; } // hoe wordt dit meegegeven?
        /// <summary>
        /// Geselecteerde/mogelijke status om op te filteren
        /// </summary>
        public string Status1 { get; set; } // hoe wordt dir meegegeven? moet dit een list<string> worden? om de filter te vullen?
    }
}