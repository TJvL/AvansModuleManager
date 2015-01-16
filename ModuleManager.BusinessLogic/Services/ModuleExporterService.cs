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

            //Document markup
            DefineStyles(prePdf);
            BuildCover(prePdf, toExport.Naam + "\n" + toExport.CursusCode);

            //Here starts the real exporting
            Section sect = prePdf.AddSection();

            ExportArguments opt = new ExportArguments(){ ExportAll = true };

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

            //Document markup
            DefineStyles(prePdf);
            BuildCover(prePdf, "Module-Overzicht voor Informatica");
            DefineTableOfContents(prePdf, pack.ToExport);

            //Here starts the real exporting

            ModuleExporterFactory mef = new ModuleExporterFactory();
            moduleExporterStrategy = mef.GetStrategy(pack.Options);
            
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


        public Stream ExportAsStream(DomainDAL.Module toExport)
        {
            MemoryStream ms = new MemoryStream();
            Export(toExport).Save(ms, false);
            byte[] bytes = ms.ToArray();

            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;

            return ms;
        }

        public Stream ExportAllAsStream(IExportablePack<DomainDAL.Module> pack)
        {
            MemoryStream ms = new MemoryStream();
            ExportAll(pack).Save(ms, false);
            byte[] bytes = ms.ToArray();

            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;

            return ms;
        }

        private void DefineStyles(Document doc) 
        {
            Style style = doc.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Black;

            Style normal = doc.Styles["Normal"];
            normal.Font.Name = "Calibri";
            normal.Font.Size = 11;

            Style h1 = doc.Styles["Heading1"];
            h1.Font.Name = "Arial";
            h1.Font.Size = 16;
            h1.Font.Bold = true;

            Style h2 = doc.Styles["Heading2"];
            h2.Font.Name = "Calibri";
            h2.Font.Size = 14;
            h2.Font.Bold = true;
            h2.Font.Italic = true;
        }

        private void BuildCover(Document doc, string coverTitle) 
        {
            Section sect = doc.AddSection();

            //this MIGHT cause trouble later...
            /*
            string tempImg = System.Environment.CurrentDirectory + "\\tempAvansLogo.jpg";

            Resources.Avans_Logo.Save(tempImg, ImageFormat.Jpeg);
            Image img = sect.AddImage(tempImg);
            img.WrapFormat.Style = WrapStyle.Through;
            img.Left = ShapePosition.Right;
            img.Top = ShapePosition.Bottom;
             */

            Paragraph p = sect.AddParagraph("\n\nAvans Hogeschool\n" + coverTitle + "\n\nDatum: " + DateTime.Now.Date.ToString("d-MM-yyyy"));
            p.Format.Font = new Font("Arial", "12");
        }

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
