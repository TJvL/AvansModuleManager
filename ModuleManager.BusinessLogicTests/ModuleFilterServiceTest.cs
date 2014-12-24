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
        IQueryablePack<Module> pack;

        [TestInitialize]
        public void setup() 
        {
            mfs = new ModuleFilterService(); //Just let it run without errors. That's a pass, I guess.
        }

        [TestMethod]
        public void testGenericSearch() 
        {
            Arguments args = new Arguments
            {
                Zoekterm = "INMODL"
            };
            var inbetween = drp.GetAll();
            var data = inbetween.AsQueryable(); ;

            pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("INMODL312345", result.First().CursusCode);
        }
    }
}
