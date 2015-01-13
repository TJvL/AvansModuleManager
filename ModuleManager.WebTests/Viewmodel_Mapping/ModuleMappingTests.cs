using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Repositories.Dummies;
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
            var module = _moduleRepository.GetOne(new object[1]{"INMODL312345"});
            var testViewModel = Mapper.Map<Module, ModuleViewModel>(module);

            // Act
            #region Expected ModuleViewModel : checkModule

            var checkModule = new ModuleViewModel
            {
                Blokken = "3",
                CursusCode = "INMODL312345",
                Docenten = "Jan Stekker, Dozijn Ei",
                FaseNamen = "Software Ontwikkeling, Business Intelligence",
                Naam = "Modelleren 3",
                Status = "Compleet(ongecontroleerd)",
                Verantwoordelijke = "Fahiem Karsodimedjo",
                TotalEc = 5
            };

            #endregion

            // Assert <expected, actual>    
            Assert.IsNotNull(testViewModel.Docenten);
            Assert.AreEqual(checkModule.CursusCode, testViewModel.CursusCode);
            Assert.AreEqual(checkModule.Blokken, testViewModel.Blokken);
            Assert.AreEqual(checkModule.Naam, testViewModel.Naam);
            Assert.AreEqual(checkModule.FaseNamen, testViewModel.FaseNamen);
            Assert.AreEqual(checkModule.Docenten, testViewModel.Docenten);
            Assert.AreEqual(checkModule.TotalEc, testViewModel.TotalEc);
            Assert.AreEqual(checkModule.Status, testViewModel.Status);
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
                        Blokken = "3",
                        CursusCode = "INMODL312345",
                        Docenten = "Jan Stekker, Dozijn Ei",
                        FaseNamen  = "Software Ontwikkeling, Business Intelligence",
                        Naam = "Modelleren 3",
                        Status = "Compleet(ongecontroleerd)",
                        Verantwoordelijke = "Fahiem Karsodimedjo",
                        TotalEc = 5
                    },
                    #endregion
                    #region expected second ModuleViewModel
                    new ModuleViewModel
                    {
                        Blokken = "3, 4",
                        CursusCode = "IN_ALG612345",
                        Docenten = "Hans Boos, Zwan Beer, Poco de Man",
                        FaseNamen = "Software Architecture, Software Testin",
                        Naam = "Algoritmiek 3000S",
                        Status = "Compleet(gecontroleerd)",
                        Verantwoordelijke = "Fahiem Karsodimedjo",
                        TotalEc = 3
                    },
                    #endregion
                    #region expected third ModuleViewModel
                    new ModuleViewModel
                    {
                        Blokken = "3, 4",
                        CursusCode = "IN_PROG4123456",
                        Docenten = "Jan Stekker, Meer Man, Poco de Man",
                        FaseNamen = "Software Architecture, Business Intelligence, TestFase",
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
            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(1).Blokken, moduleListViewModel.Modules.ElementAt(1).Blokken);

            Assert.AreEqual(checkModuleListViewModel.Modules.ElementAt(2).TotalEc, 24);
        }
    }
}
