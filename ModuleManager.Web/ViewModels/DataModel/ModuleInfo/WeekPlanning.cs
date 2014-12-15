using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.DataModel.ModuleInfo {
    public class WeekPlanning {

        public ICollection<String> Weken { get; set; }
        public ICollection<String> Onderwerpen { get; set; }
    }
}