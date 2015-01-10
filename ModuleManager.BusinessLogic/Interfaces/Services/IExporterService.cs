using ModuleManager.DomainDAL;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Interfaces.Services
{
    public interface IExporterService<T> where T : class
    {
        PdfDocument Export(T toExport);
        PdfDocument ExportAll(IExportablePack<Module> pack);
    }
}
