using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleManager.BusinessLogic.Services;
using ModuleManager.DomainDAL.Repositories.Dummies;
using ModuleManager.DomainDAL;
using System.Collections.Generic;
using PdfSharp.Pdf;
using ModuleManager.BusinessLogic.Data;

namespace ModuleManager.BusinessLogicTests
{
    [TestClass]
    public class LeerlijnExporterServiceTest
    {
        LeerlijnExporterService les;
        DummyLeerlijnRepository dlrp = new DummyLeerlijnRepository();
        List<Leerlijn> data;

        [TestInitialize]
        public void setup()
        {
            les = new LeerlijnExporterService();
            data = new List<Leerlijn>(dlrp.GetAll());
        }

        [TestMethod]
        public void TestSingleLeerlijnPdfOutput()
        {
            PdfDocument pdf = les.Export(data[1]);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\ll_pdf_1.pdf");
        }

        [TestMethod]
        public void TestMultiLeerlijnPdfOutput()
        {
            LeerlijnExportArguments args = new LeerlijnExportArguments(){ ExportAll = true };
            LeerlijnExportablePack pack = new LeerlijnExportablePack(args, data);

            PdfDocument pdf = les.ExportAll(pack);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\ll_pdf_FULL.pdf");
        }
    }
}
