using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.Web.ViewModels.PartialViewModel;
using System.Collections.Generic;
using System.Linq;

namespace ModuleManager.WebTests.Viewmodel_Mapping
{
    /// <summary>
    /// Summary description for FilterOptionsMappingTests
    /// </summary>
    [TestClass]
    public class FilterOptionsMappingTests
    {
        private DummyCompetentieRepository _competentieRepository;
        private DummyFaseRepository _faseRepository;
        private DummyLeerlijnRepository _leerlijnRepository;
        private DummyTagRepository _tagRepository;
        private DummyNiveauRepository _niveauRepository;
        private DummyStatusRepository _statusRepository;

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
            _competentieRepository = new DummyCompetentieRepository();
            _faseRepository = new DummyFaseRepository();
            _leerlijnRepository = new DummyLeerlijnRepository();
            _tagRepository = new DummyTagRepository();
            _statusRepository = new DummyStatusRepository();
            _niveauRepository = new DummyNiveauRepository();
        }

        /// <summary>
        /// Deze test methode pakt alle 'Competentie'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsCompetentie()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allCompetenties = _competentieRepository.GetAll();
            filterViewModel.AddCompetenties(allCompetenties);

            // Act
            var allCompetentieNamen = new List<string>
            {
                "Procesanalyse uitvoeren",
                "Informatieanalyse uitvoeren",
                "Over inzet van ICT adviseren",
                "Analyse van algoritmes",
                "Vernietigen van code"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allCompetentieNamen.Count, filterViewModel.CompetentieFilter.Count);
            Assert.AreEqual(allCompetentieNamen.Last(), filterViewModel.CompetentieFilter.Last());
            Assert.AreEqual(allCompetentieNamen.ElementAt(2), filterViewModel.CompetentieFilter.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle 'Niveau'-objecten van de DummyCompetentieRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsCompetenteNiveaus()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allNiveaus = _niveauRepository.GetAll();
            filterViewModel.AddCompetentieNiveaus(allNiveaus);

            // Act
            var allNiveauNiveaus = new List<string>
            {
                "Beginner",
                "Beoefend",
                "Expert"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allNiveauNiveaus.Count, filterViewModel.CompetentieNiveauFilter.Count);
            Assert.AreEqual(allNiveauNiveaus.Last(), filterViewModel.CompetentieNiveauFilter.Last());
            Assert.AreEqual(allNiveauNiveaus.ElementAt(2), filterViewModel.CompetentieNiveauFilter.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle 'Tag'-objecten van de DummyCompetentieRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsTags()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allTags = _tagRepository.GetAll();
            filterViewModel.AddTags(allTags);

            // Act
            var allTagNamen = new List<string>
            {
                "Big Data",
                "Tag1",
                "Java",
                "UML",
                "Massive Data",
                "Algoritmiek",
                "C#",
                "nested for-loops"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allTagNamen.Count, filterViewModel.TagFilter.Count);
            Assert.AreEqual(allTagNamen.Last(), filterViewModel.TagFilter.Last());
            Assert.AreEqual(allTagNamen.ElementAt(2), filterViewModel.TagFilter.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle '???'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod] // TODO:
        public void FilterOptionsBlokken()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allLeerlijnen = _leerlijnRepository.GetAll();
            filterViewModel.AddLeerlijnen(allLeerlijnen);

            // Act
            var allLeerlijnNamen = new List<string>
            {
                "Procesanalyse uitvoeren",
                "Informatieanalyse uitvoeren",
                "Over inzet van ICT adviseren",
                "Analyse van algoritmes",
                "Vernietigen van code"
            };

            // Assert <expected, actual>
        }

        /// <summary>
        /// Deze test methode pakt alle 'Leerlijn'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsLeerlijnen()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allLeerlijnen = _leerlijnRepository.GetAll();
            filterViewModel.AddLeerlijnen(allLeerlijnen);

            // Act
            var allLeerlijnNamen = new List<string>
            {
                "Algoritmiek",
                "Design Principles",
                "Databases",
                "Programmeren",
                "Console-programmas"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allLeerlijnNamen.Count, filterViewModel.LeerlijnFilter.Count);
            Assert.AreEqual(allLeerlijnNamen.Last(), filterViewModel.LeerlijnFilter.Last());
            Assert.AreEqual(allLeerlijnNamen.ElementAt(2), filterViewModel.LeerlijnFilter.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle 'Fase'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsFases()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allFases = _faseRepository.GetAll();
            filterViewModel.AddFases(allFases);

            // Act
            var allFaseNamen = new List<string>
            {
                "Software Ontwikkeling",
                "Business Intelligence",
                "Software Architecture",
                "TestFase"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allFaseNamen.Count, filterViewModel.FaseNamen.Count);
            Assert.AreEqual(allFaseNamen.Last(), filterViewModel.FaseNamen.Last());
            Assert.AreEqual(allFaseNamen.ElementAt(2), filterViewModel.FaseNamen.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle '???'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod] // TODO:
        public void FilterOptionsLeerjaren()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allStatussen = _statusRepository.GetAll();
            filterViewModel.AddStatuses(allStatussen);

            // Act
            var allStatusStatussen = new List<string>
            {
                "Incompleet",
                "Nieuw",
                "Compleet(gecontroleerd)",
                "Compleet(ongecontroleerd)"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allStatusStatussen.Count, filterViewModel.Statussen.Count);
            Assert.AreEqual(allStatusStatussen.Last(), filterViewModel.Statussen.Last());
            Assert.AreEqual(allStatusStatussen.ElementAt(2), filterViewModel.Statussen.ElementAt(2));
        }

        /// <summary>
        /// Deze test methode pakt alle '???'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod] // TODO:
        public void FilterOptionsECs()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allLeerlijnen = _leerlijnRepository.GetAll();
            filterViewModel.AddLeerlijnen(allLeerlijnen);

            // Act
            var allLeerlijnNamen = new List<string>
            {
                "Procesanalyse uitvoeren",
                "Informatieanalyse uitvoeren",
                "Over inzet van ICT adviseren",
                "Analyse van algoritmes",
                "Vernietigen van code"
            };

            // Assert <expected, actual>
        }

        /// <summary>
        /// Deze test methode pakt alle '???'-objecten van de DummyRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsStatussen()
        {
            // Arrange
            var filterViewModel = new FilterOptionsViewModel();
            var allStatussen = _statusRepository.GetAll();
            filterViewModel.AddStatuses(allStatussen);

            // Act
            var allStatusStatussen = new List<string>
            {
                "Incompleet",
                "Nieuw",
                "Compleet(gecontroleerd)",
                "Compleet(ongecontroleerd)"
            };

            // Assert <expected, actual>
            Assert.AreEqual(allStatusStatussen.Count, filterViewModel.Statussen.Count);
            Assert.AreEqual(allStatusStatussen.Last(), filterViewModel.Statussen.Last());
            Assert.AreEqual(allStatusStatussen.ElementAt(2), filterViewModel.Statussen.ElementAt(2));
        }
    }
}
