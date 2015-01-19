using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using ModuleManager.DomainDAL;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class FaseCrudViewModel
    {

        public IEnumerable<FaseType> FaseTypes { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }

    }
}