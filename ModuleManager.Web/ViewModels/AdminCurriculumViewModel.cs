using ModuleManager.Web.ViewModels.DataModel.ModuleHeader;
using ModuleManager.Web.ViewModels.DataModel.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels {
    public class AdminCurriculumViewModel {

        // DATA -START-
        public UserInfo User { get; set; }
        public ICollection<string> TagNamen { get; set; }
        public ICollection<string> CompetentieNamen { get; set; }
        public ICollection<string> LeerlijnNamen { get; set; }
        public ICollection<ExtModuleHeader> ModuleHeaders { get; set; }
        // DATA -END-
    }
}