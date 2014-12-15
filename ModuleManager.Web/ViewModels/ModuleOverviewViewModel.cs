using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels {
    public class ModuleOverviewViewModel {

        // DATA -START-
        public UserInfo User { get; set; }
        public ICollection<ModuleHeader> ModuleHeaders { get; set; }
        // DATA -END-
        public ICollection<string> CompetentieNamen { get; set; }
        public ICollection<string> TagNamen { get; set; }
        public ICollection<string> LeerlijnNamen { get; set; }
    }
}