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
    
    public partial class Module
    {
        public Module()
        {
            this.Beoordelingen = new HashSet<Beoordelingen>();
            this.Docent = new HashSet<Docent>();
            this.FaseModules = new HashSet<FaseModules>();
            this.Leerdoelen = new HashSet<Leerdoelen>();
            this.Leermiddelen = new HashSet<Leermiddelen>();
            this.ModuleCompetentie = new HashSet<ModuleCompetentie>();
            this.ModuleWerkvorm = new HashSet<ModuleWerkvorm>();
            this.StudieBelasting = new HashSet<StudieBelasting>();
            this.StudiePunten = new HashSet<StudiePunten>();
            this.Weekplanning = new HashSet<Weekplanning>();
            this.Leerlijn = new HashSet<Leerlijn>();
            this.Tag = new HashSet<Tag>();
            this.Module1 = new HashSet<Module>();
            this.Module2 = new HashSet<Module>();
        }
    
        public string CursusCode { get; set; }
        public int Schooljaar { get; set; }
        public string Beschrijving { get; set; }
        public string Naam { get; set; }
        public string Verantwoordelijke { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    
        public virtual ICollection<Beoordelingen> Beoordelingen { get; set; }
        public virtual ICollection<Docent> Docent { get; set; }
        public virtual ICollection<FaseModules> FaseModules { get; set; }
        public virtual Icons Icons { get; set; }
        public virtual ICollection<Leerdoelen> Leerdoelen { get; set; }
        public virtual ICollection<Leermiddelen> Leermiddelen { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual ICollection<ModuleCompetentie> ModuleCompetentie { get; set; }
        public virtual ICollection<ModuleWerkvorm> ModuleWerkvorm { get; set; }
        public virtual ICollection<StudieBelasting> StudieBelasting { get; set; }
        public virtual ICollection<StudiePunten> StudiePunten { get; set; }
        public virtual ICollection<Weekplanning> Weekplanning { get; set; }
        public virtual ICollection<Leerlijn> Leerlijn { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }
        public virtual ICollection<Module> Module1 { get; set; }
        public virtual ICollection<Module> Module2 { get; set; }
    }
}
