using ModuleManager.DomainDAL;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Ajax.Utilities;
using System;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    /// <summary>
    /// Deze klasse heeft twee functies:
    ///     - Doorgeven aan de views, welke filtermogelijkheden er zijn en welke kolommen mogelijk zijn voor weergave
    ///     - Het accepteren van de, door de gebruikers geselecteerde, filters/sorters aan de back-end
    /// </summary>
    public class FilterOptionsViewModel
    {
        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Competentie'-objecten alleen de namen en zet deze in het 'CompetentieFilter' Property
        /// </summary>
        /// <param name="competentieList">Lijst van alle 'Competentie'-objecten</param>
        public void AddCompetenties(IEnumerable<Competentie> competentieList)
        {
            CompetentieFilter = competentieList
                .Select(comp => comp.Naam)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Niveau'-objecten alleen het niveau en zet deze in het 'CompetentieNiveauFilter' Property
        /// </summary>
        /// <param name="niveauList">Lijst van alle 'Niveau'-objecten</param>
        public void AddCompetentieNiveaus(IEnumerable<Niveau> niveauList)
        {
            CompetentieNiveauFilter = niveauList
                .Select(niveau => niveau.Niveau1)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Tag'-objecten alleen de namen en zet deze in het 'TagFilter' Property
        /// </summary>
        /// <param name="tagList">Lijst van alle 'Tag'-objecten</param>
        public void AddTags(IEnumerable<Tag> tagList)
        {
            TagFilter = tagList
                .Select(tag => tag.Naam)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Leerlijn'-objecten alleen de namen en zet deze in het 'TagFilter' Property
        /// </summary>
        /// <param name="leerlijnenList">Lijst van alle 'Leerlijn'-objecten</param>
        public void AddLeerlijnen(IEnumerable<Leerlijn> leerlijnenList)
        {
            LeerlijnFilter = leerlijnenList
                .Select(comp => comp.Naam)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Module'-objecten alleen de 'Distinct'-Blokken en zet deze in het 'Blokken' Property
        /// </summary>
        /// <remarks>
        /// Mogelijke vervangende parameters zouden zijn:
        /// -IEnumerable van FaseModule
        /// -IEnumerable van Fase
        /// </remarks>
        /// <param name="moduleList"></param>
        public void AddBlokken(IEnumerable<Module> moduleList)
        {
            Blokken = moduleList
                .SelectMany(module => module.FaseModules)
                .Select(fm => fm.Blok)
                .Distinct()
                .ToList();
        }


        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Fase'-objecten alleen de namen en zet deze in het 'FaseNamen' Property
        /// </summary>
        /// <param name="faseList">Lijst van alle 'Fase'-objecten</param>
        public void AddFases(IEnumerable<Fase> faseList)
        {
            FaseNamen = faseList
                .Select(fase => fase.Naam)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Module'-objecten alleen 'Distinct'-Leerjaren en zet deze in het 'FaseNamen' Property
        /// </summary>
        /// <param name="moduleList">Lijst van alle 'Module'-objecten</param>
        public void AddLeerjaren(IEnumerable<Module> moduleList)
        {
            Leerjaren = moduleList
                .DistinctBy(module => module.Schooljaar)
                .Select(module => module.Schooljaar)
                .ToList();
        }

        /// <summary>
        /// Verkrijgt, uit een lijst van alle 'Module'-objecten, de totale EC per Module en zet deze in het 'ECs' Property
        /// </summary>
        /// <param name="moduleList">Lijst van alle 'Module'-objecten</param>
        public void AddECs(IEnumerable<Module> moduleList)
        {
            ECs = moduleList
                .DistinctBy(module => module.StudiePunten
                    .Select(sp => sp.EC))
                .Select(module => module.StudiePunten
                    .Sum(sp => Convert.ToInt32(sp.EC)))
                .ToList();
        }

        /// <summary>
        /// Verkrijgt uit een lijst van alle 'Status'-objecten alleen de status en zet deze in het 'Statussen' Property
        /// </summary>
        /// <param name="statusList">Lijst van alle 'Status'-objecten</param>
        public void AddStatuses(IEnumerable<Status> statusList)
        {
            Statussen = statusList
                .Select(status => status.Status1)
                .ToList();
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
        public ICollection<string> Blokken { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke fasenaam(namen) om op te filteren
        /// </summary>
        public ICollection<string> FaseNamen { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke Leerjaar om op te filteren
        /// </summary>
        public ICollection<int> Leerjaren { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke EC(s) om op te filteren
        /// </summary>
        public ICollection<int> ECs { get; set; }
        /// <summary>
        /// Geselecteerde/mogelijke status om op te filteren
        /// </summary>
        public ICollection<string> Statussen { get; set; }
    }
}