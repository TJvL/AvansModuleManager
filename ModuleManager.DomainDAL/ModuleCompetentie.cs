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
    
    public partial class ModuleCompetentie
    {
        public string CursusCode { get; set; }
        public string Schooljaar { get; set; }
        public string CompetentieCode { get; set; }
        public string CompetentieSchooljaar { get; set; }
        public string Niveau { get; set; }
    
        public virtual Competentie Competentie { get; set; }
        public virtual Module Module { get; set; }
        public virtual Niveau Niveau1 { get; set; }
    }
}
