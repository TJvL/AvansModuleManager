﻿using ModuleManager.DomainDAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ModuleManager.Web.ViewModels.PartialViewModel
{

    public class ModuleCrudViewModel
    {
        public string Naam { get; set; }
        public string Verantwoordelijke { get; set; }
        public string CursusCode { get; set; }
        public string Blok { get; set; }
        public string Icon { get; set; }
        public string Onderdeel { get; set; }

        [Required]
        //[DisplayName("Toetscode")]
        public string Toetscode1 { get; set; }
        public string Toetscode2 { get; set; }

        [Required]
        public decimal Ec1 { get; set; }
        public decimal Ec2 { get; set; }

        public string[] SelectedFases { get; set; }

        //public IEnumerable<Fase> SelectedFases { get; set; }

        public IEnumerable<Fase> Fases { get; set; }

        public IEnumerable<Blok> Blokken { get; set; }

        public IEnumerable<Icons> Icons { get; set; }

        public IEnumerable<Onderdeel> Onderdelen { get; set; }

        //public IEnumerable<StudiePunten> StudiePunten { get; set; }

    }

}