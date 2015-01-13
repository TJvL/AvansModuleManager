using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using PdfSharp.Pdf;

namespace ModuleManager.BusinessLogic.Services
{
    public class DummyModuleExporterService : IExporterService<Module>
    {
        public PdfDocument Export(Module toExport)
        {
            Document pre = new Document();
            pre.AddSection();

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = pre;
            rend.RenderDocument();
            return rend.PdfDocument;
        }

        public PdfDocument ExportAll(IExportablePack<Module> pack)
        {
            Document pre = new Document();
            pre.AddSection();

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = pre;
            rend.RenderDocument();
            return rend.PdfDocument;
        }
    }
}
