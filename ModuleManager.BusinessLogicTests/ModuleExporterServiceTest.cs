using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.DomainDAL;
using ModuleManager.DomainDAL.Repositories.Dummies;
using PdfSharp.Pdf;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class ModuleExporterServiceTest
    {
        ModuleExporterService mes;
        DummyModuleRepository drp = new DummyModuleRepository();
        List<Module> data;

        [TestInitialize]
        public void setup() 
        {
            mes = new ModuleExporterService();
            data = new List<Module>(drp.GetAll());
        }

        [TestMethod]
        public void TestSingleModulePdfOutput()
        {
            PdfDocument pdf = mes.Export(data[1]);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\pdf_1.pdf");
        }

        [TestMethod]
        public void TestMultiModulePdfOutput() 
        {
            ModuleExportArguments opt = new ModuleExportArguments(){ ExportAll = true };
            ModuleExportablePack pack = new ModuleExportablePack(opt, data);
            PdfDocument pdf = mes.ExportAll(pack);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\pdf_FULL.pdf");
        }
    }
}
