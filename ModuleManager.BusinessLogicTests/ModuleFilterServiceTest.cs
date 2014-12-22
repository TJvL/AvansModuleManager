using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Services;
using System.Linq;
using ModuleManager.DomainDAL;
using System.Collections.Generic;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class ModuleFilterServiceTest
    {
        ModuleFilterService mfs;
        List<Module> data;

        [TestInitialize]
        public void setup() 
        {
            //get data
        }

        [TestMethod]
        public void testConstructor()
        {
            mfs = new ModuleFilterService(); //Just let it run without errors. That's a pass, I guess.
        }
    }
}
