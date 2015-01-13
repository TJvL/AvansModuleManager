using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Filters.ModuleFilterStack
{
    public class ModuleGenericZoektermFilter : ModuleBaseFilter
    {
        public ModuleGenericZoektermFilter(IFilter<Module> parent) : base(parent) { }
        public override IQueryable<Module> Filter(IQueryable<Module> toQuery, Arguments args)
        {
            if (args.ZoektermFilter != null) 
            {
                toQuery = from m in toQuery where 
                              m.Beschrijving.Contains(args.ZoektermFilter) || 
                              m.CursusCode.Contains(args.ZoektermFilter) || 
                              (from d in m.Docent select d.Name).Contains(args.ZoektermFilter) ||
                              (from l in m.Leerdoelen select l.Beschrijving).Contains(args.ZoektermFilter) ||
                              (from l in m.Leerdoelen select l.CursusCode).Contains(args.ZoektermFilter) ||
                              (from l in m.Leerlijn select l.Naam).Contains(args.ZoektermFilter) ||
                              (from lm in m.Leermiddelen select lm.Beschrijving).Contains(args.ZoektermFilter) ||
                              (from lm in m.Leermiddelen select lm.CursusCode).Contains(args.ZoektermFilter) ||
                              m.Naam.Contains(args.ZoektermFilter) ||
                              (from t in m.Tag select t.Naam).Contains(args.ZoektermFilter) ||
                              m.Verantwoordelijke.Contains(args.ZoektermFilter) 
                          select m; 
            }

            return base.Filter(toQuery, args);
        }
    }
}
