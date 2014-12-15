using ModuleManager.Web.ViewModels.DataModel.ModuleHeader;
using ModuleManager.Web.ViewModels.DataModel.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels {
    public class AdminCheckModuleViewModel {

        // DATA -START-
        public UserInfo User { get; set; }
        public ICollection<CheckModuleHeader> ModuleHeaders { get; set; }
        // DATA -END-
    }
}