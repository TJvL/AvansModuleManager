using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Exporters
{
    public interface IExporter<T> where T : class
    {
        Section Export(T toExport, Section sect);
    }
}
