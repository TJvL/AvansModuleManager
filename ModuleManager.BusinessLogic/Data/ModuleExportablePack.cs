﻿using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Pack containing any and all items to use for exporting to PDF
    /// </summary>
    public class ModuleExportablePack : IExportablePack<Module>
    {
        ExportOptions _options;
        IEnumerable<Module> _toExport;

        /// <summary>
        /// Constructor to build a pack
        /// </summary>
        /// <param name="opt">Pre-made options pack indicating what to export</param>
        /// <param name="data">The modules to export data from</param>
        public ModuleExportablePack(ExportOptions opt, IEnumerable<Module> data) 
        {
            this._options = opt;
            this._toExport = data;
        }

        /// <summary>
        /// The options indicating what to export
        /// </summary>
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

        /// <summary>
        /// The data from which to export
        /// </summary>
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
