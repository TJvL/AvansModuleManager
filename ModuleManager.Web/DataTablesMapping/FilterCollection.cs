using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuleManager.Web.DataTablesMapping
{
    public class FilterCollection
    {
        public IReadOnlyCollection<string> CompetentieFilters { get; set; }
        public IReadOnlyCollection<string> NiveauFilters { get; set; }
        public IReadOnlyCollection<string> FaseFilters { get; set; }
        public IReadOnlyCollection<string> BlokFilters { get; set; }
        public IReadOnlyCollection<string> TagFilters { get; set; }
        public string SchooljaarFilter { get; set; }

        public FilterCollection(IEnumerable<string> competenties, IEnumerable<string> niveaus, IEnumerable<string> fases,
            IEnumerable<string> blokken, IEnumerable<string> tags, string schooljaar)
        {
            CompetentieFilters = competenties.ToList().AsReadOnly();
            NiveauFilters = niveaus.ToList().AsReadOnly();
            FaseFilters = fases.ToList().AsReadOnly();
            BlokFilters = blokken.ToList().AsReadOnly();
            TagFilters = tags.ToList().AsReadOnly();
            SchooljaarFilter = schooljaar;
        }
    }
}