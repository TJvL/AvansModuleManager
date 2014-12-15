using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.DataModel.ModuleHeader {
    public class CheckModuleHeader : ModuleHeader {

        public string Status { get; set; }
        public string Verantwoordelijke { get; set; }
        public string VakDocenten { get; set; }

        /*public ??? Icon { get; set; }*/
    }
}