//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModuleManager.DomainDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fase
    {
        public Fase()
        {
            this.FaseModules = new HashSet<FaseModules>();
        }
    
        public string Naam { get; set; }
        public System.DateTime Schooljaar { get; set; }
        public string Beschrijving { get; set; }
        public string FaseType { get; set; }
        public string OpleidingNaam { get; set; }
        public System.DateTime OpleidingSchooljaar { get; set; }
    
        public virtual Opleiding Opleiding { get; set; }
        public virtual ICollection<FaseModules> FaseModules { get; set; }
    }
}
