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
    public class CompetentieExporterServiceTest
    {
        CompetentieExporterService ces;
        DummyCompetentieRepository dcrp = new DummyCompetentieRepository();
        List<Competentie> data;

        [TestInitialize]
        public void setup()
        {
            ces = new CompetentieExporterService();
            data = new List<Competentie>(dcrp.GetAll());
        }

        [TestMethod]
        public void TestSingleCompetentiePdfOutput()
        {
            PdfDocument pdf = ces.Export(data[1]);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\cp_pdf_1.pdf");
        }

        [TestMethod]
        public void TestMultiCompetentiePdfOutput()
        {
            CompetentieExportArguments args = new CompetentieExportArguments() { ExportAll = true };
            CompetentieExportablePack pack = new CompetentieExportablePack(args, data);

            PdfDocument pdf = ces.ExportAll(pack);
            pdf.Save("D:\\Education\\Proj_blk6\\TestIO\\cp_pdf_FULL.pdf");
        }
    }
}
