using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.DomainDAL.Repositories.Dummies;
using ModuleManager.DomainDAL.Repositories;
using System.Linq;
using ModuleManager.DomainDAL;
using ModuleManager.BusinessLogic.Data;
using System.Collections.Generic;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class ModuleFilterSorterServiceTest
    {
        ModuleFilterSorterService mfss;
        DummyModuleRepository drp = new DummyModuleRepository();
        IQueryable<Module> data;

        [TestInitialize]
        public void setup() 
        {
            mfss = new ModuleFilterSorterService();
            data = drp.GetAll().AsQueryable();
        }

        [TestMethod]
        public void TestFilterSorterCombo()
        {
            Arguments args = new Arguments();
            args.SortFor.Add("Naam", true);

            List<string> tags = new List<string>();
            tags.Add("C#");

            args.TagFilter = tags;

            ModuleQueryablePack toProcess = new ModuleQueryablePack(args, data);

            var processed = mfss.ProcessData(toProcess);

            Assert.IsNotNull(processed);
            Assert.AreEqual(2, processed.Count());
            Assert.AreEqual("Algoritmiek 3000S", processed.Last().Naam);
            Assert.AreEqual("Programmeren 7", processed.First().Naam);
        }
    }
}
