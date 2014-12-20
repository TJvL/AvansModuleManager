using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.Web.ViewModels.PartialViewModel;

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
        }

        /// <summary>
        /// Deze test methode pakt alle 'Competentie'-objecten van de DummyCompetentieRepository en mapt deze naar een FilterOptionsViewModel
        /// </summary>
        [TestMethod]
        public void FilterOptionsCompetentie()
        {
            // Arrange
            var FilterViewModel = new FilterOptionsViewModel();

            // Act

            // Assert <expected, actual>
        }
    }
}
