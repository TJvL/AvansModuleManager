//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace ModuleManager.DomainDAL {
    public partial class FaseModules {
        public string FaseNaam { get; set; }
        public DateTime FaseSchooljaar { get; set; }
        public string ModuleCursusCode { get; set; }
        public DateTime ModuleSchooljaar { get; set; }
        public string Blok { get; set; }
        public string OpleidingNaam { get; set; }
        public DateTime OpleidingSchooljaar { get; set; }

        public virtual Fase Fase { get; set; }
        public virtual Module Module { get; set; }
    }
}
