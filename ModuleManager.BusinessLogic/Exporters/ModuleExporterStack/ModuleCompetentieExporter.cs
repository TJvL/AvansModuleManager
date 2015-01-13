using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Exporters.ModuleExporterStack
{
    public class ModuleCompetentieExporter : ModuleBaseExporter
    {
        /// <summary>
        /// Constructor for stacking decorators
        /// </summary>
        /// <param name="parent">The previous decorator pattern</param>
        public ModuleCompetentieExporter(IExporter<Module> parent) : base(parent) { }

        /// <summary>
        /// Export skills to a section in a document
        /// </summary>
        /// <param name="toExport">The data to export from</param>
        /// <param name="sect">The section to write on</param>
        /// <returns>The section with appended data</returns>
        public override Section Export(Module toExport, Section sect) 
        {
            base.Export(toExport, sect);

            //custom code
            Paragraph p = sect.AddParagraph();
            p.AddText("Competenties");
            p.AddLineBreak();
            p.AddText("DE CODE VAN DIT STUK MODULE IS EEN ROTZOOI? PLACEHOLDER: " + toExport.ModuleCompetentie.First().Competentie.Beschrijving);
            p.AddLineBreak();
            p.AddLineBreak();

            return sect;
        }
    }
}
