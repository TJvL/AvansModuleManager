using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Services;
using System.Linq;
using ModuleManager.DomainDAL;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Data;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class ModuleFilterServiceTest
    {
        ModuleFilterService mfs;
        DummyModuleRepository drp = new DummyModuleRepository();
        IQueryable<Module> data;

        [TestInitialize]
        public void setup() 
        {
            mfs = new ModuleFilterService(); //Just let it run without errors. That's a pass, I guess.
            data = drp.GetAll().AsQueryable();
        }

        [TestMethod]
        public void testGenericSearch() 
        {
            Arguments args = new Arguments
            {
                Zoekterm = "INMODL"
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("INMODL312345", result.First().CursusCode);
        }

        [TestMethod]
        public void testCompetentieSearchSingle()
        {
            List<string> filtering = new List<string>();
            filtering.Add("procesanaly");

            Arguments args = new Arguments
            {
                CompetentieFilter = filtering
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void testCompetentieSearchMulti()
        {
            List<string> filtering = new List<string>();
            filtering.Add("procesanaly");
            filtering.Add("vernietigen");

            Arguments args = new Arguments
            {
                CompetentieFilter = filtering
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }
    }
}
