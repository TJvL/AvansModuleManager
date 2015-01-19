using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ModuleLockViewModel
    {
        public string CursusCode { get; set; }
        public string Schooljaar { get; set; }
        public bool Blocked { get; set; }
    }
}