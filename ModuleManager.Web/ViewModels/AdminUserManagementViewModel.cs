using ModuleManager.Web.ViewModels.DataModel.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels {
    public class AdminUserManagementViewModel {

        // DATA -START-
        public UserInfo User { get; set; }
        public ICollection<ExtUserInfo> Users { get; set; }
        // DATA -END-
    }
}