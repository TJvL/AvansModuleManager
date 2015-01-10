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
    public class ModuleWeekPlanningExporter : ModuleBaseExporter
    {
        public ModuleWeekPlanningExporter(IExporter<Module> parent) : base(parent) { }

        public override Section Export(Module toExport, Section sect) 
        {
            base.Export(toExport, sect);

            //custom code
            Paragraph p = sect.AddParagraph();
            p.AddText("Weekplanning");
            p.AddLineBreak();
            p.AddText("PLACEHOLDER");
            p.AddLineBreak();
            p.AddLineBreak();

            return sect;
        }
    }
}
