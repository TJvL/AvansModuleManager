using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.RequestViewModels
{
    public class ExportArgumentsViewModel
    {
        public Filter Filters { get; set; }
        public Export Export { get; set; }
    }
}