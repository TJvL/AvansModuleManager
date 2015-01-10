using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.DomainDAL;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Exporters
{
    public abstract class ModuleBaseExporter : IExporter<Module>
    {
        IExporter<Module> parent;

        public ModuleBaseExporter(IExporter<Module> parent) 
        {
            this.parent = parent;
        }

        public virtual Section Export(Module toExport, Section sect)
        {
            return parent.Export(toExport, sect);
        }
    }
}
