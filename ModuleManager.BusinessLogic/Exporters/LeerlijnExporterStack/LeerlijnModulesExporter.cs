using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Exporters.LeerlijnExporterStack
{
    public class LeerlijnModulesExporter : LeerlijnBaseExporter
    {
        /// <summary>
        /// Constructor for stacking decorators
        /// </summary>
        /// <param name="parent">The previous decorator pattern</param>
        public LeerlijnModulesExporter(IExporter<Leerlijn> parent) : base(parent) { }

        /// <summary>
        /// Export name to a section in a document
        /// </summary>
        /// <param name="toExport">The data to export from</param>
        /// <param name="sect">The section to write on</param>
        /// <returns>The section with appended data</returns>
        public override Section Export(Leerlijn toExport, Section sect)
        {
            base.Export(toExport, sect);

            //custom code
            Paragraph p = sect.AddParagraph("Modules in Deze leerlijn", "Heading2");
            p.AddLineBreak();

            p = sect.AddParagraph();
            p.AddFormattedText("De leerlijnen zijn klikbaar in PDF viewers").Font.Color = Colors.DarkGray;
            foreach (Module m in toExport.Module) 
            {
                p.AddFormattedText(" - " + m.Naam + "\n").Font.Bold = true;
                List<Leerlijn> otherLines = m.Leerlijn.ToList();
                foreach (Leerlijn l in otherLines) 
                {
                    if(!l.Naam.Equals(toExport.Naam))
                    {
                        Hyperlink hyperlink = p.AddHyperlink(l.Naam);
                        hyperlink.AddText("    - " + l.Naam);
                        hyperlink.AddPageRefField(l.Naam);
                        hyperlink.Font.Underline = Underline.Dash;
                    }
                }
            }
            p.AddLineBreak();

            return sect;
        }
    }
}
