using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.Web;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.WebTests.Viewmodel_Mapping
{
    /// <summary>
    /// Summary description for ViewmodelMappingTests
    /// </summary>
    [TestClass]
    public class ModuleMappingTests
    {
        private DummyModuleRepository _moduleRepository;

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestInitialize]
        public void ModuleListViewModelMappingTestInit()
        {
            _moduleRepository = new DummyModuleRepository();
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// Deze test methode pakt de eerste 'Module' van de DummyModuleRepository en mapt deze naar een ModuleViewModel
        /// </summary>
        [TestMethod]
        public void ModuleToViewModelMappingTest()
        {
            // Arrange
            var module = _moduleRepository.GetOne("INMODL312345");
            var testViewModel = Mapper.Map<Module, ModuleViewModel>(module);

            // Act
            #region Expected ModuleViewModel : checkModule

            var checkModule = new ModuleViewModel
            {
                Blok = new List<int>
                {
                    3
                },
                CursusCode = "INMODL312345",
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
                Naam = "Modelleren 3",
                Status = "Compleet(ongecontroleerd)",
                Verantwoordelijke = "Fahiem Karsodimedjo",
                TotalEc = 5
            };

            #endregion

            // Assert <expected, actual>
            Assert.IsNotNull(testViewModel.Docent);
            Assert.AreEqual(checkModule.CursusCode, testViewModel.CursusCode);
            Assert.AreEqual(checkModule.Blok.ElementAt(0), testViewModel.Blok.ElementAt(0));
            Assert.AreEqual(checkModule.Naam, testViewModel.Naam);
            Assert.AreEqual(checkModule.FaseModules.Count, testViewModel.FaseModules.Count);
            Assert.AreEqual(checkModule.Docent.ElementAt(0).Id, testViewModel.Docent.ElementAt(0).Id);
            Assert.AreEqual(checkModule.Docent.ElementAt(1).Name, testViewModel.Docent.ElementAt(1).Name);
            Assert.AreEqual(checkModule.FaseModules.ElementAt(0).FaseNaam, testViewModel.FaseModules.ElementAt(0).FaseNaam);
            Assert.AreEqual(checkModule.TotalEc, testViewModel.TotalEc);
        }

        /// <summary>
        /// Deze test methode pakt alle 'Module'-objecten van de DummyModuleRepository en mapt deze naar een ModuleListViewModel
        /// </summary>
        [TestMethod]
        public void ModulesToListViewModelTest()
        {
            // Arrange
            var modules = _moduleRepository.GetAll();
            var moduleListViewModel = new ModuleListViewModel(modules.Count());
            moduleListViewModel.AddModules(modules);

            // Act
            #region Expected ModuleListViewModel : checkModuleListViewModel

            var checkModuleListViewModel = new ModuleListViewModel(3)
            {
                Modules = new List<ModuleViewModel>
                {
                    #region expected first ModuleViewModel
                    new ModuleViewModel
                    {
                        Blok = new List<int>
                        {
                            3
                        },
                        CursusCode = "INMODL312345",
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
                        Naam = "Modelleren 3",
                        Status = "Compleet(ongecontroleerd)",
                        Verantwoordelijke = "Fahiem Karsodimedjo",
                        TotalEc = 5
                    },
                    #endregion
                    #region expected second ModuleViewModel
                    new ModuleViewModel
                    {
                        Blok = new List<int>
                        {
                            3,4
                        },
                        CursusCode = "IN_ALG612345",
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
                        Naam = "Algoritmiek 3000S",
                        Status = "Compleet(gecontroleerd)",
                        Verantwoordelijke = "Fahiem Karsodimedjo",
                        TotalEc = 3
                    },
                    #endregion
                    #region expected third ModuleViewModel
                    new ModuleViewModel
                    {
                        Blok = new List<int>
                        {
                            3,4
                        },
                        CursusCode = "IN_PROG4123456",
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
				                Name = "Meer man",
				                Schooljaar = 1415
				            },
				            new Docent
				            {
				                Id = 3,
				                CursusCode = "IN_PROG4123456",
				                Name = "Poco de Man",
				                Schooljaar = 1415
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
                        Naam = "Programmeren 7",
                        Status = "Incompleet",
                        Verantwoordelijke = "Fahiem Karsodimedjo",
                        TotalEc = 24
                    }
                    #endregion
                }
            };

            #endregion

            // Assert <expected, actual>
            Assert.AreEqual(checkModuleListViewModel.RecordsFiltered, moduleListViewModel.RecordsFiltered);
            Assert.AreEqual(checkModuleListViewModel.RecordsTotal, moduleListViewModel.RecordsTotal);
            Assert.AreEqual(checkModuleListViewModel.Modules.Count, moduleListViewModel.Modules.Count);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(0).Status, moduleListViewModel.Modules.ElementAt(0).Status);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(1).Status, moduleListViewModel.Modules.ElementAt(1).Status);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).Status, moduleListViewModel.Modules.ElementAt(2).Status);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).TotalEc, moduleListViewModel.Modules.ElementAt(2).TotalEc);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(1).Blok.Count, moduleListViewModel.Modules.ElementAt(1).Blok.Count);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(1).Blok.ElementAt(0), moduleListViewModel.Modules.ElementAt(1).Blok.ElementAt(0));
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(1).Blok.ElementAt(1), moduleListViewModel.Modules.ElementAt(1).Blok.ElementAt(1));
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).Blok.Count, moduleListViewModel.Modules.ElementAt(2).Blok.Count);

            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).Blok.Count, 2);
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).TotalEc, 24);
        }
    }
}
