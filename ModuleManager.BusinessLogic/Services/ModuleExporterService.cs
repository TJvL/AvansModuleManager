using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Exporters;
using ModuleManager.BusinessLogic.Factories;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.BusinessLogic.Properties;
using ModuleManager.DomainDAL;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    public class ModuleExporterService : AbstractExporterService, IExporterService<DomainDAL.Module>
    {
        IExporter<DomainDAL.Module> moduleExporterStrategy;
        

        public ModuleExporterService() 
        {
            //can't be null.
            moduleExporterStrategy = new ModulePassiveExporter();
        }

        /// <summary>
        /// Basic export function to generate PDF from one element
        /// </summary>
        /// <param name="toExport">element to export</param>
        /// <returns>A PDF Document</returns>
        public PdfDocument Export(DomainDAL.Module toExport)
        {
            Document prePdf = new Document();

            //Document markup
            DefineStyles(prePdf);
            BuildCover(prePdf, toExport.Naam + "\n" + toExport.CursusCode);

            //Here starts the real exporting
            Section sect = prePdf.AddSection();

            ModuleExportArguments opt = new ModuleExportArguments(){ ExportAll = true };

            ModuleExporterFactory mef = new ModuleExporterFactory();
            moduleExporterStrategy = mef.GetStrategy(opt);

            sect = moduleExporterStrategy.Export(toExport, sect);

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = prePdf;
            rend.RenderDocument();
            return rend.PdfDocument;
        }

        /// <summary>
        /// Basic export function to generate PDF from a list of elements
        /// </summary>
        /// <param name="pack">pack containing elements to export and arguments to specify the format</param>
        /// <returns>A PDF Document</returns>
        public PdfDocument ExportAll(IExportablePack<DomainDAL.Module> pack)
        {
            Document prePdf = new Document();

            //Document markup
            DefineStyles(prePdf);
            BuildCover(prePdf, "Module-Overzicht voor Informatica");
            DefineTableOfContents(prePdf, pack.ToExport);

            //Here starts the real exporting

            ModuleExporterFactory mef = new ModuleExporterFactory();
            moduleExporterStrategy = mef.GetStrategy(pack.Options as ModuleExportArguments);
            
            foreach(DomainDAL.Module m in pack.ToExport)
            {
                Section sect = prePdf.AddSection();
                sect = moduleExporterStrategy.Export(m, sect);

                //Page numbers (only for multi-export)
                Paragraph p = new Paragraph();
                p.AddPageField();
                sect.Footers.Primary.Add(p);
                sect.Footers.EvenPage.Add(p.Clone());
            }

            PdfDocumentRenderer rend = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            rend.Document = prePdf;
            rend.RenderDocument();
            return rend.PdfDocument;
        }

        /// <summary>
        /// Encaspulated single export as stream for downloading
        /// </summary>
        /// <param name="toExport">element to export</param>
        /// <returns>Stream to offer as download</returns>
        public BufferedStream ExportAsStream(DomainDAL.Module toExport)
        {
            MemoryStream ms = new MemoryStream();
            Export(toExport).Save(ms, false);
            byte[] bytes = ms.ToArray();

            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;

            return new BufferedStream(ms);
        }

        /// <summary>
        /// Encaspulated multi export as stream for downloading
        /// </summary>
        /// <param name="pack"></param>
        /// <returns>Stream to offer as download</returns>
        public BufferedStream ExportAllAsStream(IExportablePack<DomainDAL.Module> pack)
        {
            MemoryStream ms = new MemoryStream();
            ExportAll(pack).Save(ms, false);
            byte[] bytes = ms.ToArray();

            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;

            return new BufferedStream(ms);
        }

        /// <summary>
        /// Builds a table of contents, based on the content
        /// </summary>
        /// <param name="doc">The document to define for</param>
        /// <param name="contents">The content</param>
        private void DefineTableOfContents(Document doc, IEnumerable<Module> contents) 
        {
            Section sect = doc.LastSection;

            sect.AddPageBreak();
            Paragraph p = sect.AddParagraph("Inhoudsopgave", "Heading1");
            p.Format.SpaceAfter = 24;
            p.Format.OutlineLevel = OutlineLevel.Level1;

            foreach (Module m in contents)
            {
                Paragraph p2 = sect.AddParagraph();
                p2.Style = "TOC";
                Hyperlink hyperlink = p2.AddHyperlink(m.Naam);
                hyperlink.AddText(m.Naam+"\t");
                hyperlink.AddPageRefField(m.Naam);
            }
        }
    }
}
