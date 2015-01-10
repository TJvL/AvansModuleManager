using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    public class ModuleExportablePack : IExportablePack<Module>
    {
        ExportOptions _options;
        IEnumerable<Module> _toExport;

        public ModuleExportablePack(ExportOptions opt, IEnumerable<Module> data) 
        {
            this._options = opt;
            this._toExport = data;
        }

        public ExportOptions Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
            }
        }

        public IEnumerable<Module> ToExport
        {
            get
            {
                return _toExport;
            }
            set
            {
                _toExport = value;
            }
        }
    }
}
