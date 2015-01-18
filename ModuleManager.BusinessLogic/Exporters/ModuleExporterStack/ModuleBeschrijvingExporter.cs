﻿using MigraDoc.DocumentObjectModel;
using ModuleManager.BusinessLogic.Interfaces.Exporters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Exporters.ModuleExporterStack
{
    public class ModuleBeschrijvingExporter : ModuleBaseExporter
    {
        /// <summary>
        /// Constructor for stacking decorators
        /// </summary>
        /// <param name="parent">The previous decorator pattern</param>
        public ModuleBeschrijvingExporter(IExporter<Module> parent) : base(parent) { }

        /// <summary>
        /// Export the description to a section in a document
        /// </summary>
        /// <param name="toExport">The data to export from</param>
        /// <param name="sect">The section to write on</param>
        /// <returns>The section with appended data</returns>
        public override Section Export(Module toExport, Section sect) 
        {
            base.Export(toExport, sect);

            //custom code
            Paragraph p = sect.AddParagraph();
            p.AddLineBreak();
            p.AddText(toExport.Beschrijving.Replace("$$", "\n"));
            p.AddLineBreak();

            return sect;
        }
    }
}
