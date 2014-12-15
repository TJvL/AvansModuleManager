using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.DataModel.ModuleHeader {
    public class ExtModuleHeader : ModuleHeader {

        public virtual string Status { get; set; }

        public virtual string Verantwoordelijke { get; set; }
    }
}