﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class ModuleSorterServiceTest
    {
        ModuleSorterService mss;
        DummyModuleRepository drp = new DummyModuleRepository();
        IQueryable<Module> data;

        [TestInitialize]
        public void setup() 
        {
            mss = new ModuleSorterService(); //Just let it run without errors. That's a pass, I guess.
            data = drp.GetAll().AsQueryable();
        }

        [TestMethod]
        public void testEmptySorting() 
        {
            FilterSorterArguments args = new FilterSorterArguments();

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mss.Sort(pack);
            Assert.IsNotNull(result);
            //No need to check for count. That is not modified anywhere in this sequence.
        }

        [TestMethod]
        public void testModuleNaamSorting() 
        {
            FilterSorterArguments args = new FilterSorterArguments();
            args.SortArguments.Add("Naam", false);

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mss.Sort(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual("Algoritmiek 3000S", result.First().Naam);
            Assert.AreEqual("Programmeren 7", result.Last().Naam);
        }
    }
}
