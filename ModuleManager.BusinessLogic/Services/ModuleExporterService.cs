using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Exporters;
using ModuleManager.BusinessLogic.Factories;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.BusinessLogic.Interfaces.Services;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    public class ModuleExporterService : IExporterService<DomainDAL.Module>
    {
        IExporter<DomainDAL.Module> moduleExporterStrategy;
        

        public ModuleExporterService() 
        {
            //can't be null.
            moduleExporterStrategy = new ModulePassiveExporter();
        }

        public PdfDocument Export(DomainDAL.Module toExport)
        {
            Document prePdf = new Document();
            Section sect = prePdf.AddSection();

            ExportOptions opt = new ExportOptions(){ ExportAll = true };

            ModuleExporterFactory mef = new ModuleExporterFactory();
            moduleExporterStrategy = mef.GetStrategy(opt);

            sect = moduleExporterStrategy.Export(toExport, sect);

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = prePdf;
            rend.RenderDocument();
            return rend.PdfDocument;
        }

        public PdfDocument ExportAll(IExportablePack<DomainDAL.Module> pack)
        {
            Document prePdf = new Document();

            ModuleExporterFactory mef = new ModuleExporterFactory();
            moduleExporterStrategy = mef.GetStrategy(pack.Options);
            
            foreach(DomainDAL.Module m in pack.ToExport)
            {
                Section sect = prePdf.AddSection();
                sect = moduleExporterStrategy.Export(m, sect);
            }

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = prePdf;
            rend.RenderDocument();
            return rend.PdfDocument;
        }
    }
}
