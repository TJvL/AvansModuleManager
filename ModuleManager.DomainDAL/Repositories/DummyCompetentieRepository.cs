using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
namespace ModuleManager.DomainDAL.Repositories
{
    public class DummyCompetentieRepository : IGenericRepository<Competentie>
    {
        private readonly ICollection<Competentie> _competenties;

        public DummyCompetentieRepository()
        {
            _competenties = new List<Competentie>
			{
				new Competentie
				{
                    Code = "BC-01",
					Naam = "Procesanalyse uitvoeren",
					Beschrijving = "De student is in staat om:" +
					"1. de verschillende elementen van een proces te herkennen en onderscheiden." +
					"2. door middel van interviews te achterhalen hoe een bedrijfsproces in werkelijkheid verloopt, en waar de knelpunten zitten." +
					"3. contradicties in de verschillende interviews te herkennen en op te lossen." +
					"4. schema’s van processen te maken die passen bij de probleemstelling en duidelijk zijn voor andere belanghebbenden." +
					"5. te kunnen bepalen of de analyse volledig is ten aanzien van de probleemstelling." +
					"6. aan te geven op welke punten het proces verbeterd kan worden, of zelfs een compleet nieuw proces te ontwerpen." +
					"7. aan te geven welke keuzes gemaakt zijn tijdens het onderzoek en de analyse, en welke argumenten daarvoor gebruikt zijn." +
					"8. aan te geven waar de informatie voor de analyse vandaan komt en wat de betrouwbaarheid daarvan is.",
					Schooljaar = 1415
				},
				new Competentie
				{
                    Code = "BC-02",
					Naam = "Informatieanalyse uitvoeren",
					Beschrijving = "De student kan:" +
					"1. op basis van een procesanalyse onderzoeken welke informatiestromen er zijn in relatie tot die processen." +
					"2. onderzoeken en aangeven welke gegevens in verzamelingen vastgelegd moeten worden." +
					"3. een globaal ontwerp maken van deze verzamelingen." +
					"4. het resultaat documenteren op een voor alle belanghebbenden duidelijke manier, zonder inconsistenties, waarbij een keuze gemaakt wordt uit toepasselijke modelleertechnieken." +
					"5. overleggen met gebruikers en opdrachtgevers over de juistheid en betrouwbaarheid van de gevonden modellen." +
					"− E1: op basis van een bedrijfs- en procesanalyse een ontwerp maken van de presentatie van informatie aan de eindgebruiker.",
					Schooljaar = 1415
				},
				new Competentie
				{
                    Code = "BC-03",
					Naam = "Over inzet van ICT adviseren",
					Beschrijving = "De student kan:" +
					"1. vanuit een proces en informatieanalyse aangeven welke verbeteringen nodig zijn." +
					"2. aangeven hoe ICT hierbij gebruikt wordt en waarom dit nodig is om de gewenste verbeteringen te realiseren." +
					"3. uitleggen aan derden wat het advies inhoudt en waarom dat past bij de probleemstelling." +
					"− E1: breedte van het onderzoek, heldere criteria, goede argumentatie, voldoende inleven in het standpunt van de klant, een duidelijk advies, een goede presentatie, juiste vorm van het rapport en goed nederlands." +
					"− E2: kan een advies opstellen over het inrichten van een applicatieserver." +
					"− E3: kan advies geven over I-voorzieningen; infoplan, infobeleid.",
					Schooljaar = 1415
				},
				new Competentie
				{
                    Code = "BC-04",
					Naam = "Analyse van algoritmes",
					Beschrijving = "De student kan:" +
					"1. op basis van een procesanalyse onderzoeken welke informatiestromen er zijn in relatie tot die processen." +
					"2. onderzoeken en aangeven welke gegevens in verzamelingen vastgelegd moeten worden." +
					"3. een globaal ontwerp maken van deze verzamelingen." +
					"4. het resultaat documenteren op een voor alle belanghebbenden duidelijke manier, zonder inconsistenties, waarbij een keuze gemaakt wordt uit toepasselijke modelleertechnieken." +
					"5. overleggen met gebruikers en opdrachtgevers over de juistheid en betrouwbaarheid van de gevonden modellen." +
					"− E1: op basis van een bedrijfs- en procesanalyse een ontwerp maken van de presentatie van informatie aan de eindgebruiker.",
					Schooljaar = 1415
				},
				new Competentie
				{
                    Code = "BC-05",
					Naam = "Vernietigen van code",
					Beschrijving = "De student kan:" +
					"1. vanuit een proces en informatieanalyse aangeven welke verbeteringen nodig zijn." +
					"2. aangeven hoe ICT hierbij gebruikt wordt en waarom dit nodig is om de gewenste verbeteringen te realiseren." +
					"3. uitleggen aan derden wat het advies inhoudt en waarom dat past bij de probleemstelling." +
					"− E1: breedte van het onderzoek, heldere criteria, goede argumentatie, voldoende inleven in het standpunt van de klant, een duidelijk advies, een goede presentatie, juiste vorm van het rapport en goed nederlands.",
					Schooljaar = 1415
				}
			};
        }

        public IEnumerable<Competentie> GetAll()
        {
            return _competenties;
        }

        public Competentie GetOne(string key)
        {
            return (_competenties.Where(comp => comp.Code.Equals(key))).First();
        }

        public bool Create(Competentie entity)
        {
            if (_competenties != null)
            {
                _competenties.Add(entity);
                return true;
            }
            return false;
        }

        public bool Delete(Competentie entity)
        {
            return _competenties.Remove(entity);
        }

        public bool Edit(Competentie entity)
        {
            Competentie oldComp = (_competenties.Where(comp => comp.Code.Equals(entity.Code))).First();
            if (Delete(oldComp))
            {
                return Create(entity);
            }
            return false;
        }
    }
}