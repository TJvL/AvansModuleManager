//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace ModuleManager.DomainDAL {
    public partial class Leerlijn {
        public Leerlijn() {
            this.Module = new HashSet<Module>();
        }

        public string Naam { get; set; }
        public DateTime Schooljaar { get; set; }
        public string Beschrijving { get; set; }

        public virtual ICollection<Module> Module { get; set; }
    }
}
