using System.Collections.Generic;
using System.Linq;
using ModuleManager.DomainDAL.Interfaces;
namespace ModuleManager.DomainDAL.Repositories
{
    public class ModuleRepository : IGenericRepository<Module>
    {
        private readonly IList<Module> _modules;
        private readonly ModuleManager.DomainDAL.DomainContext dbContext;

        public ModuleRepository()
        {
            _modules = new List<Module>
			{
                #region first module
				new Module
				{
					CursusCode = "INMODL312345",
					Naam = "Modelleren 3",
					Status = "Compleet(ongecontroleerd)",
					Beoordelingen = new List<Beoordelingen>
					{
						new Beoordelingen
						{
							CursusCode = "INMODL312345",
							Id = 1,
							Beschrijving = "MODL-TH: Tentamen voor Modelleren 3, Minimaal een 4"
						},
						new Beoordelingen
						{
							CursusCode = "INMODL312345",
							Id = 2,
							Beschrijving = "MODL-PR: Voor alle opdrachten van de workshops moeten minimaal een 4 gehaald worden"
						}
					},
					Schooljaar = 1415,
					Beschrijving = 	"Dit is de module voor Modelleren 3" +
									"Hier leer je hoe je gedoe moet doen" +
									"UML en diagrammen enzo.",
					Leermiddelen = new List<Leermiddelen>
					{
						new Leermiddelen
						{
							Id = 1,
							Beschrijving = "Gebruik van blackboard",
							Schooljaar = 1415,
							CursusCode = "INMODL312345"
						},
						new Leermiddelen
						{
							Id = 2,
							Beschrijving = "De website: kokkerelen met UML",
							Schooljaar = 1415,
							CursusCode = "INMODL312345"
						},
						new Leermiddelen
						{
							Id = 3,
							Beschrijving = "Gebruik van het boek 'modelleren voor stumperds'",
							Schooljaar = 1415,
							CursusCode = "INMODL312345"
						}
					},
					Leerdoelen = new List<Leerdoelen>
					{
						new Leerdoelen
						{
							Id = 1,
							Beschrijving = "Het kunnen modelleren van software.",
							Schooljaar = 1415,
							CursusCode = "INMODL312345"
						},
						new Leerdoelen
						{
							Id = 2,
							Beschrijving = "UML-diagrammen kunnen maken en begrijpen",
							Schooljaar = 1415,
							CursusCode = "INMODL312345"
						}
					},
					StudieBelasting = new List<StudieBelasting>
					{
						new StudieBelasting
						{
							Id = 1,
							CursusCode = "INMODL312345",
							Schooljaar = 1415,
							Activiteit = "Workshop",
							Duur = "100 weken",
							Frequentie = "16 x weeks",
							SBU = 1200
						},
						new StudieBelasting
						{
							Id = 1,
							CursusCode = "INMODL312345",
							Schooljaar = 1415,
							Activiteit = "Hoorcollege",
							Duur = "250 weken",
							Frequentie = "42 x weeks",
							SBU = 1200
						}
					},
					Verantwoordelijke = "Fahiem Karsodimedjo",
					ModuleWerkvorm = new List<ModuleWerkvorm>
					{
						new ModuleWerkvorm
						{
							CursusCode = "INMODL312345",
							WerkvormType = "HC",
							Schooljaar = 1415,
							Organisatie = "In het hoorcollege geeft de docent steeds een korte toelichting over de nieuwe stof"
						},
						new ModuleWerkvorm
						{
							CursusCode = "INMODL312345",
							WerkvormType = "WS",
							Schooljaar = 1415,
							Organisatie = "In de workshop worden practicum opdrachten gemaakt en besproken"
						}
					},
					FaseModules = new List<FaseModules>
					{
						new FaseModules
						{
							FaseNaam = "Software Ontwikkeling",
							FaseSchooljaar = 1415,
							ModuleCursusCode = "INMODEL312345",
							ModuleSchooljaar = 1415,
							Blok = "3",
							OpleidingNaam = "Informatica",
							OpleidingSchooljaar = 1415
						},
						new FaseModules
						{
							FaseNaam = "Business Intelligence",
							FaseSchooljaar = 1415,
							ModuleCursusCode = "INMODEL312345",
							ModuleSchooljaar = 1415,
							Blok = "3",
							OpleidingNaam = "Informatica",
							OpleidingSchooljaar = 1415
						}
					},
					Leerlijn = new List<Leerlijn>
					{
						new Leerlijn
						{
							Naam = "Programmeren",
							Schooljaar = 1415
						},
						new Leerlijn
						{
							Naam = "Algoritmiek",
							Schooljaar = 1415
						},
						new Leerlijn
						{
							Naam = "Design Principles",
							Schooljaar = 1415
						},
						new Leerlijn
						{
							Naam = "Databases",
							Schooljaar = 1415
						}
					},
					Tag = new List<Tag>
					{
						new Tag
						{
							Naam = "Big Data",
							Schooljaar = 1415
						},
						new Tag
						{
							Naam = "Java",
							Schooljaar = 1415
						},
						new Tag
						{
							Naam = "UML",
							Schooljaar = 1415
						}
					},
					ModuleCompetentie = new List<ModuleCompetentie>
					{
						new ModuleCompetentie
						{
						Competentie = new Competentie
						{
							Naam = "Procesanalyse uitvoeren",
							Beschrijving = "De student is in staat om: $$" +
							"1. de verschillende elementen van een proces te herkennen en onderscheiden$$" +
							"2. door middel van interviews te achterhalen hoe een bedrijfsproces in werkelijkheid verloopt, en waar de knelpunten zitten$$" +
							"3. contradicties in de verschillende interviews te herkennen en op te lossen$$" +
							"4. schema’s van processen te maken die passen bij de probleemstelling en duidelijk zijn voor andere belanghebbenden$$" +
							"5. te kunnen bepalen of de analyse volledig is ten aanzien van de probleemstelling$$" +
							"6. aan te geven op welke punten het proces verbeterd kan worden, of zelfs een compleet nieuw proces te ontwerpen$$" +
							"7. aan te geven welke keuzes gemaakt zijn tijdens het onderzoek en de analyse, en welke argumenten daarvoor gebruikt zijn$$" +
							"8. aan te geven waar de informatie voor de analyse vandaan komt en wat de betrouwbaarheid daarvan is",
							Schooljaar = 1415
						},
						Niveau = "Beginner",
						Schooljaar = 1415
						},
						new ModuleCompetentie
						{
						Competentie = new Competentie
						{
							Naam = "Informatieanalyse uitvoeren",
							Beschrijving = "De student kan:$$" +
							"1. op basis van een procesanalyse onderzoeken welke informatiestromen er zijn in relatie tot die processen$$" +
							"2. onderzoeken en aangeven welke gegevens in verzamelingen vastgelegd moeten worden$$" +
							"3. een globaal ontwerp maken van deze verzamelingen$$" +
							"4. het resultaat documenteren op een voor alle belanghebbenden duidelijke manier, zonder inconsistenties, waarbij een keuze gemaakt wordt uit toepasselijke modelleertechnieken$$" +
							"5. overleggen met gebruikers en opdrachtgevers over de juistheid en betrouwbaarheid van de gevonden modellen$$" +
							"− E1: op basis van een bedrijfs- en procesanalyse een ontwerp maken van de presentatie van informatie aan de eindgebruiker",
							Schooljaar = 1415
						},
						Niveau = "Expert",
						Schooljaar = 1415
						}
					},
					StudiePunten = new List<StudiePunten>
					{
						new StudiePunten
						{
							ToetsCode = "MOD-PR",
							EC = 2
						},
						new StudiePunten
						{
							ToetsCode = "MOD-TH",
							EC = 3
						}
					},
					Weekplanning = new List<Weekplanning>
					{
						new Weekplanning
						{
							Id = 1,
							CursusCode = "INMODEL312345",
							Schooljaar = 1415,
							Week = "1-2",
							Onderwerp = "pannekoeken"
						},
						new Weekplanning
						{
							Id = 2,
							CursusCode = "INMODEL312345",
							Schooljaar = 1415,
							Week = "3-7",
							Onderwerp = "koken van pannekoeken"
						},
						new Weekplanning
						{
							Id = 3,
							CursusCode = "INMODEL312345",
							Schooljaar = 1415,
							Week = "1-2",
							Onderwerp = "pannekoeken"
						}
					},
					Docent = new List<Docent>
					{
						new Docent
						{
							Id = 1,
							CursusCode = "INMODEL312345",
							Name = "Jan Stekker",
							Schooljaar = 1415
						},
						new Docent
						{
							Id = 2,
							CursusCode = "INMODEL312345",
							Name = "Dozijn Ei",
							Schooljaar = 1415
						}
					}
				},
                #endregion
                #region second module
				new Module
				{
				    CursusCode = "IN_ALG612345",
				    Naam = "Algoritmiek 3000S",
				    Status = "Compleet(gecontroleerd)",
				    Beoordelingen = new List<Beoordelingen>
				    {
				        new Beoordelingen
				        {
				            CursusCode = "IN_ALG612345",
				            Id = 1,
				            Beschrijving = "ALG-TH: Tentamen voor Modelleren 3, Minimaal een 4"
				        },
				        new Beoordelingen
				        {
				            CursusCode = "IN_ALG612345",
				            Id = 2,
				            Beschrijving = "ALG-PR: Voor alle opdrachten van de workshops moeten minimaal een 4 gehaald worden"
				        }
				    },
				    Schooljaar = 1415,
				    Beschrijving = "Dit is de module voor Algoritmiek 3000S." +
				    "Hier leer je hoe je algoritmieken moet doen en maken.",
				    Leermiddelen = new List<Leermiddelen>
				    {
				        new Leermiddelen
				        {
				            Id = 1,
				            Beschrijving = "Gebruik van blackboard",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leermiddelen
				        {
				            Id = 2,
				            Beschrijving = "De website: Algoritmiek wikipedia",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leermiddelen
				        {
				            Id = 3,
				            Beschrijving = "Gebruik van het boek 'Algoritmiek voor beginners'",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        }
				    },
				    Leerdoelen = new List<Leerdoelen>
				    {
				        new Leerdoelen
				        {
				            Id = 1,
				            Beschrijving = "Weten hoe efficient elke behandelde sorteermethode is.",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leerdoelen
				        {
				            Id = 2,
				            Beschrijving = "Sorteeralgoritmes kunnen maken en begrijpen.",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        }
				    },
				    StudieBelasting = new List<StudieBelasting>
				    {
				        new StudieBelasting
				        {
				            Id = 1,
				            CursusCode = "IN_ALG612345",
				            Schooljaar = 1415,
				            Activiteit = "Workshop",
				            Duur = "100 weken",
				            Frequentie = "16 x weeks",
				            SBU = 1200
				        },
				        new StudieBelasting
				        {
				            Id = 2,
				            CursusCode = "IN_ALG612345",
				            Schooljaar = 1415,
				            Activiteit = "Hoorcollege",
				            Duur = "250 weken",
				            Frequentie = "42 x weeks",
				            SBU = 1200
				        }
				    },
				    Verantwoordelijke = "Fahiem Karsodimedjo",
				    ModuleWerkvorm = new List<ModuleWerkvorm>
				    {
				        new ModuleWerkvorm
				        {
				            CursusCode = "IN_ALG612345",
				            WerkvormType = "HC",
				            Schooljaar = 1415,
				            Organisatie = "In het hoorcollege geeft de docent steeds een korte toelichting over de nieuwe stof"
				        },
				        new ModuleWerkvorm
				        {
				            CursusCode = "IN_ALG612345",
				            WerkvormType = "WS",
				            Schooljaar = 1415,
				            Organisatie = "In de workshop worden practicum opdrachten gemaakt en besproken"
				        }
				    },
				    FaseModules = new List<FaseModules>
				    {
				        new FaseModules
				        {
				            FaseNaam = "Software Architecture",
				            FaseSchooljaar = 1415,
				            ModuleCursusCode = "IN_ALG612345",
				            ModuleSchooljaar = 1415,
				            Blok = "3",
				            OpleidingNaam = "Informatica",
				            OpleidingSchooljaar = 1415
				        },
                        new FaseModules
				        {
				            FaseNaam = "Software Testin",
				            FaseSchooljaar = 1415,
				            ModuleCursusCode = "IN_ALG612345",
				            ModuleSchooljaar = 1415,
				            Blok = "4",
				            OpleidingNaam = "Informatica",
				            OpleidingSchooljaar = 1415
				        }
				    },
				    Leerlijn = new List<Leerlijn>
				    {
				        new Leerlijn
				        {
				            Naam = "Programmeren",
				            Schooljaar = 1415
				        },
				        new Leerlijn
				        {
				            Naam = "Algoritmiek",
				            Schooljaar = 1415
				        },
				        new Leerlijn
				        {
				            Naam = "Console-programmas",
				            Schooljaar = 1415
				        }
				    },
				    Tag = new List<Tag>
				    {
				        new Tag
				        {
				            Naam = "Massive Data",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "Algoritmiek",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "C#",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "nested for-loops",
				            Schooljaar = 1415
				        }
				    },
				    ModuleCompetentie = new List<ModuleCompetentie>
				    {
				        new ModuleCompetentie
				        {
				            Competentie = new Competentie
				            {
                                Code = "BO-02",
				                Naam = "Informatieanalyse uitvoeren",
				                Beschrijving = "De student kan:$$" +
				                "1. op basis van een procesanalyse onderzoeken welke informatiestromen er zijn in relatie tot die processen$$" +
				                "2. onderzoeken en aangeven welke gegevens in verzamelingen vastgelegd moeten worden$$" +
				                "3. een globaal ontwerp maken van deze verzamelingen$$" +
				                "4. het resultaat documenteren op een voor alle belanghebbenden duidelijke manier, zonder inconsistenties, waarbij een keuze gemaakt wordt uit toepasselijke modelleertechnieken$$" +
				                "5. overleggen met gebruikers en opdrachtgevers over de juistheid en betrouwbaarheid van de gevonden modellen$$" +
				                "− E1: op basis van een bedrijfs- en procesanalyse een ontwerp maken van de presentatie van informatie aan de eindgebruiker",
				                Schooljaar = 1415
				            },
				            Niveau = "Beginner"
				        },
				        new ModuleCompetentie
				        {
				            Competentie = new Competentie
				            {
                                Code = "BO-01",
				                Naam = "Procesanalyse uitvoeren",
				                Beschrijving = "De student is in staat om: $$" +
				                "1. de verschillende elementen van een proces te herkennen en onderscheiden$$" +
				                "2. door middel van interviews te achterhalen hoe een bedrijfsproces in werkelijkheid verloopt, en waar de knelpunten zitten$$" +
				                "3. contradicties in de verschillende interviews te herkennen en op te lossen$$" +
				                "4. schema’s van processen te maken die passen bij de probleemstelling en duidelijk zijn voor andere belanghebbenden$$" +
				                "5. te kunnen bepalen of de analyse volledig is ten aanzien van de probleemstelling$$" +
				                "6. aan te geven op welke punten het proces verbeterd kan worden, of zelfs een compleet nieuw proces te ontwerpen$$" +
				                "7. aan te geven welke keuzes gemaakt zijn tijdens het onderzoek en de analyse, en welke argumenten daarvoor gebruikt zijn$$" +
				                "8. aan te geven waar de informatie voor de analyse vandaan komt en wat de betrouwbaarheid daarvan is",
				                Schooljaar = 1415
				            },
				            Niveau = "Expert"
				        }
				    },
				    StudiePunten = new List<StudiePunten>
				    {
				        new StudiePunten
				        {
				            ToetsCode = "ALG-PR",
				            EC = 1
				        },
				        new StudiePunten
				        {
				            ToetsCode = "ALG-TH",
				            EC = 2
				        }
				    },
				    Weekplanning = new List<Weekplanning>
				    {
				        new Weekplanning
				        {
				        Id = 1,
				        CursusCode = "INMODEL312345",
				        Schooljaar = 1415,
				        Week = "1",
				        Onderwerp = "Algoritmiek"
				        },
				        new Weekplanning
				        {
				            Id = 2,
				            CursusCode = "INMODEL312345",
				            Schooljaar = 1415,
				            Week = "2-4",
				            Onderwerp = "Bubblesort"
				        },
				        new Weekplanning
				        {
				            Id = 3,
				            CursusCode = "INMODEL312345",
				            Schooljaar = 1415,
				            Week = "1-2",
				            Onderwerp = "Reverse inverse super complicated supersort"
				        }
				    },
				    Docent = new List<Docent>
				    {
				        new Docent
				        {
				            Id = 1,
				            CursusCode = "INMODEL312345",
				            Name = "Hans Boos",
				            Schooljaar = 1415
				        },
				        new Docent
				        {
				            Id = 2,
				            CursusCode = "INMODEL312345",
				            Name = "Zwan Beer",
				            Schooljaar = 1415
				        },
				        new Docent
				        {
				            Id = 3,
				            CursusCode = "INMODEL312345",
				            Name = "Poco de Man",
				            Schooljaar = 1415
				        }
				    }
				},
                #endregion
                #region third module
				new Module
				{
				    CursusCode = "IN_PROG4123456",
				    Naam = "Programmeren 7",
				    Status = "Incompleet",
				    Beoordelingen = new List<Beoordelingen>
				    {
				        new Beoordelingen
				        {
				            CursusCode = "IN_PROG4123456",
				            Id = 1,
				            Beschrijving = "PROG-AS: Week 7 & 8 heb je tijd om een assesment te maken."
				        }
				    },
				    Schooljaar = 1415,
				    Beschrijving = "Dit is de module voor Programmeren 7$$" +
				    "Hier leer je hoe je gedoe moet doen$$" +
				    "allerlei onzin maar toch niet helemaal",
				    Leermiddelen = new List<Leermiddelen>
				    {
				        new Leermiddelen
				        {
				            Id = 1,
				            Beschrijving = "Gebruik van blackboard",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leermiddelen
				        {
				            Id = 2,
				            Beschrijving = "De website: kokkerelen met pannen en koeken",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leermiddelen
				        {
				            Id = 3,
				            Beschrijving = "Gebruik van het boek 'Algoritmiek voor beginners'",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leermiddelen
				        {
				            Id = 4,
				            Beschrijving = "Webdictaat via blackboard",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        }
				    },
				    Leerdoelen = new List<Leerdoelen>
				    {
				        new Leerdoelen
				        {
				            Id = 1,
				            Beschrijving = "Het kunnen modelleren van software, UML vor beginners kennen",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        },
				        new Leerdoelen
				        {
				            Id = 2,
				            Beschrijving = "UML-diagrammen kunnen maken",
				            Schooljaar = 1415,
				            CursusCode = "IN_ALG612345"
				        }
				    },
				    StudieBelasting = new List<StudieBelasting>
				    {
				        new StudieBelasting
				        {
				            Id = 1,
				            CursusCode = "IN_PROG4123456",
				            Schooljaar = 1415,
				            Activiteit = "Workshop",
				            Duur = "100 weken",
				            Frequentie = "16 x weeks",
				            SBU = 1200
				        },
				        new StudieBelasting
				        {
				            Id = 1,
				            CursusCode = "IN_PROG4123456",
				            Schooljaar = 1415,
				            Activiteit = "Hoorcollege",
				            Duur = "250 weken",
				            Frequentie = "42 x weeks",
				            SBU = 1200
				        }
				    },
				    Verantwoordelijke = "Fahiem Karsodimedjo",
				    ModuleWerkvorm = new List<ModuleWerkvorm>
				    {
				        new ModuleWerkvorm
				        {
				            CursusCode = "IN_PROG4123456",
				            WerkvormType = "HC",
				            Schooljaar = 1415,
				            Organisatie = "In het hoorcollege geeft de docent steeds een korte toelichting over de nieuwe stof"
				        },
				        new ModuleWerkvorm
				        {
				            CursusCode = "IN_PROG4123456",
				            WerkvormType = "WS",
				            Schooljaar = 1415,
				            Organisatie = "In de workshop worden practicum opdrachten gemaakt en besproken"
				        }
				    },
				    FaseModules = new List<FaseModules>
				    {
				        new FaseModules
				        {
				            FaseNaam = "Software Architecture",
				            FaseSchooljaar = 1415,
				            ModuleCursusCode = "IN_PROG4123456",
				            ModuleSchooljaar = 1415,
				            Blok = "3",
				            OpleidingNaam = "Informatica",
				            OpleidingSchooljaar = 1415
				        },
                        new FaseModules
				        {
				            FaseNaam = "Business Intelligence",
				            FaseSchooljaar = 1415,
				            ModuleCursusCode = "IN_PROG4123456",
				            ModuleSchooljaar = 1415,
				            Blok = "3",
				            OpleidingNaam = "Informatica",
				            OpleidingSchooljaar = 1415
				        },
                        new FaseModules
				        {
				            FaseNaam = "TestFase",
				            FaseSchooljaar = 1415,
				            ModuleCursusCode = "IN_PROG4123456",
				            ModuleSchooljaar = 1415,
				            Blok = "4",
				            OpleidingNaam = "Informatica",
				            OpleidingSchooljaar = 1415
				        }
				    },
				    Leerlijn = new List<Leerlijn>
				    {
				        new Leerlijn
				        {
				            Naam = "Programmeren",
				            Schooljaar = 1415
				        },
				        new Leerlijn
				        {
				            Naam = "Console-programmas",
				            Schooljaar = 1415
				        }
				    },
				    Tag = new List<Tag>
				    {
				        new Tag
				        {
				            Naam = "Massive Data",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "Algoritmiek",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "Java",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "C#",
				            Schooljaar = 1415
				        },
				        new Tag
				        {
				            Naam = "nested for-loops",
				            Schooljaar = 1415
				        }
				    },
				    ModuleCompetentie = new List<ModuleCompetentie>
				    {
				        new ModuleCompetentie
				        {
				            Competentie = new Competentie
				            {
                                Code = "BC-03",
				                Naam = "Analyse van algoritmes",
				                Beschrijving = "De student kan:$$" +
				                "1. op basis van een procesanalyse onderzoeken welke informatiestromen er zijn in relatie tot die processen$$" +
				                "2. onderzoeken en aangeven welke gegevens in verzamelingen vastgelegd moeten worden$$" +
				                "3. een globaal ontwerp maken van deze verzamelingen$$" +
				                "4. het resultaat documenteren op een voor alle belanghebbenden duidelijke manier, zonder inconsistenties, waarbij een keuze gemaakt wordt uit toepasselijke modelleertechnieken$$" +
				                "5. overleggen met gebruikers en opdrachtgevers over de juistheid en betrouwbaarheid van de gevonden modellen$$" +
				                "− E1: op basis van een bedrijfs- en procesanalyse een ontwerp maken van de presentatie van informatie aan de eindgebruiker",
				                Schooljaar = 1415
				            },
				            Niveau = "Expert"
				        },
				        new ModuleCompetentie
				        {
				            Competentie = new Competentie
				            {
                                Code = "BC-03",
				                Naam = "Vernietigen van code",
				                Beschrijving = "De student kan:$$" +
				                "1. vanuit een proces en informatieanalyse aangeven welke verbeteringen nodig zijn$$" +
				                "2. aangeven hoe ICT hierbij gebruikt wordt en waarom dit nodig is om de gewenste verbeteringen te realiseren$$" +
				                "3. uitleggen aan derden wat het advies inhoudt en waarom dat past bij de probleemstelling$$" +
				                "− E1: breedte van het onderzoek, heldere criteria, goede argumentatie, voldoende inleven in het standpunt van de klant, een duidelijk advies, een goede presentatie, juiste vorm van het rapport en goed nederlands",
				                Schooljaar = 1415
				            },
				            Niveau = "Expert"
				        }
				    },
				    StudiePunten = new List<StudiePunten>
				    {
				        new StudiePunten
				        {
				            ToetsCode = "PROG-PR",
				            EC = 12
				        },
				        new StudiePunten
				        {
				            ToetsCode = "PROG-TH",
				            EC = 12
				        }
				    },
				    Weekplanning = new List<Weekplanning>
				    {
				        new Weekplanning
				        {
				            Id = 1,
				            CursusCode = "IN_PROG4123456",
				            Schooljaar = 1415,
				            Week = "1-2",
				            Onderwerp = "C#"
				        },
				        new Weekplanning
				        {
				            Id = 2,
				            CursusCode = "IN_PROG4123456",
				            Schooljaar = 1415,
				            Week = "3-7",
				            Onderwerp = "Java"
				        },
				        new Weekplanning
				        {
				            Id = 3,
				            CursusCode = "IN_PROG4123456",
				            Schooljaar = 1415,
				            Week = "8-10",
				            Onderwerp = "Assembly"
				        }
				    },
				    Docent = new List<Docent>
				    {
				        new Docent
				        {
				            Id = 1,
				            CursusCode = "IN_PROG4123456",
				            Name = "Jan Stekker",
				            Schooljaar = 1415
				        },
				        new Docent
				        {
				            Id = 2,
				            CursusCode = "IN_PROG4123456",
				            Name = "Meer Man",
				            Schooljaar = 1415
				        },
				        new Docent
				        {
				            Id = 3,
				            CursusCode = "IN_PROG4123456",
				            Name = "Poco de Man",
				            Schooljaar = 1415
				        }
				    }
                }
                #endregion
			};
        }

        public IEnumerable<Module> GetAll()
        {
            return (from b in dbContext.Module select b).ToList();
        }

        public Module GetOne(string key)
        {
            return (from b in dbContext.Module where b.CursusCode.Equals(key) select b).First();
        }

        public bool Create(Module entity)
        {
            if (dbContext == null)
                return false;
            dbContext.Entry<Module>(entity).State = System.Data.Entity.EntityState.Added;
            int changesCount = dbContext.SaveChanges();

            if (changesCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Module entity)
        {
            dbContext.Entry<Module>(entity).State = System.Data.Entity.EntityState.Deleted;
            int changes = dbContext.SaveChanges();

            if (changes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(Module entity)
        {
            dbContext.Entry<Module>(entity).State = System.Data.Entity.EntityState.Modified;
            int changes = dbContext.SaveChanges();

            if (changes == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}