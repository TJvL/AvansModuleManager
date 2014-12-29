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
            if (args.Zoekterm != null) 
            {
                toQuery = from m in toQuery where 
                              m.Beschrijving.Contains(args.Zoekterm) || 
                              m.CursusCode.Contains(args.Zoekterm) || 
                              (from d in m.Docent select d.Name).Contains(args.Zoekterm) ||
                              (from l in m.Leerdoelen select l.Beschrijving).Contains(args.Zoekterm) ||
                              (from l in m.Leerdoelen select l.CursusCode).Contains(args.Zoekterm) ||
                              (from l in m.Leerlijn select l.Naam).Contains(args.Zoekterm) ||
                              (from lm in m.Leermiddelen select lm.Beschrijving).Contains(args.Zoekterm) ||
                              (from lm in m.Leermiddelen select lm.CursusCode).Contains(args.Zoekterm) ||
                              m.Naam.Contains(args.Zoekterm) ||
                              (from t in m.Tag select t.Naam).Contains(args.Zoekterm) ||
                              m.Verantwoordelijke.Contains(args.Zoekterm) 
                          select m; 
            }

            return base.Filter(toQuery, args);
        }
    }
}
