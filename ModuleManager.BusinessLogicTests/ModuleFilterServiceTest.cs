using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Services;
using System.Linq;
using ModuleManager.DomainDAL;
using System.Collections.Generic;
using ModuleManager.DomainDAL.Repositories;
using ModuleManager.DomainDAL.Repositories.Dummies;
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
        public void testGenericFilter() 
        {
            Arguments args = new Arguments
            {
                ZoektermFilter = "INMODL"
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("INMODL312345", result.First().CursusCode);
        }

        [TestMethod]
        public void testCompetentieFilterSingle() //These tests were for testing the concept of the listXlist filter. (find if any string in this list contains any string from the other list)
        {
            List<string> competentie = new List<string>();
            competentie.Add("procesanaly");

            Arguments args = new Arguments
            {
                CompetentieFilters = competentie
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void testCompetentieFilterMulti() //These tests were for testing the concept of the listXlist filter.
        {
            List<string> competentie = new List<string>();
            competentie.Add("procesanaly");
            competentie.Add("vernietigen");

            Arguments args = new Arguments
            {
                CompetentieFilters = competentie
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void testEmptyFilter()
        {
            Arguments args = new Arguments();

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void testAllFilters() //Excluding the special-case generic filter
        {
            List<string> competentie = new List<string>();
            competentie.Add("procesanaly");

            List<string> competentieNiveau = new List<string>();
            competentieNiveau.Add("ginner");

            List<string> tag = new List<string>();
            tag.Add("Java");

            List<string> leerlijn = new List<string>();
            leerlijn.Add("algo");

            List<int> blokken = new List<int>();
            blokken.Add(3);

            List<string> faseNamen = new List<string>();
            faseNamen.Add("Intell");

            int leerjaar = 1415;

            List<int> EC = new List<int>();
            EC.Add(3);

            string status = "Comple";

            Arguments args = new Arguments
            {
                CompetentieFilters = competentie,
                CompetentieNiveauFilters = competentieNiveau,
                TagFilters = tag,
                LeerlijnFilters = leerlijn,
                BlokFilters = blokken,
                FaseFilters = faseNamen,
                LeerjaarFilter = leerjaar,
                ECfilters = EC,
                StatusFilter = status
            };

            ModuleQueryablePack pack = new ModuleQueryablePack(args, data);

            IEnumerable<Module> result;
            result = mfs.Filter(pack);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("INMODL312345", result.First().CursusCode);
        }
    }
}
