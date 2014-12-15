using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.DataModel.ModuleHeader {
    public class ModuleHeader {

        public virtual string ModuleNaam { get; set; }
        public virtual string CursusCode { get; set; }
        public virtual int Blok { get; set; }
        public virtual StudiePunten StudiePunt { get; set; }
    }
}