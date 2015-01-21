
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.Web.ViewModels.PartialViewModel;

namespace ModuleManager.WebTests.Viewmodel_Mapping
{
    /// <summary>
    /// Summary description for StudieGidsViewModelTests
    /// </summary>
    [TestClass]
    public class StudieGidsViewModelTests
    {
        [TestMethod]
        public void TotaleContactUren()
        {
            var lesTabelViewModel = new LesTabelViewModel
            {
                Modules = new List<ModuleTabelViewModel>
                {
                    new ModuleTabelViewModel
                    {
                        Contacturen = "12+1"
                    },
                    new ModuleTabelViewModel
                    {
                        Contacturen = "12+1"
                    },
                    new ModuleTabelViewModel
                    {
                        Contacturen = "11+1+42 + 2"
                    }
                }
            };

            var expectedData = (2 * 13) + 11 + 1 + 42 + 2;

            Assert.AreEqual(expectedData, lesTabelViewModel.TotaleContactUren);
        }
    }
}
