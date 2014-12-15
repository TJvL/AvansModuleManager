using ModuleManager.Web.ViewModels.DataModel.ModuleInfo;
using ModuleManager.Web.ViewModels.DataModel.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels {
    public class ModuleDetailViewModel {

        // DATA -START-
        public UserInfo User { get; set; }
        public ModuleInfo ModuleInfo { get; set; }
        // DATA -END-
    }
}