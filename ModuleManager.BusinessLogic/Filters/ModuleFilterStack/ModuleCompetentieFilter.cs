﻿using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Filters.ModuleFilterStack
{
    public class ModuleCompetentieFilter : ModuleBaseFilter
    {
        public ModuleCompetentieFilter(IFilter<Module> parent) : base(parent) { }
        public override IQueryable<Module> Filter(IQueryable<Module> toQuery, FilterSorterArguments args)
        {
            if (args.CompetentieFilters != null)
            {
                List<Module> result = new List<Module>();
                foreach (string arg in args.CompetentieFilters)
                {
                    var selectedModule = 
                        from m in toQuery
                            where
                                m.ModuleCompetentie.Any(
                                element => element.Competentie.Naam.ToLower().Contains(arg.ToLower())
                                )
                        select m;

                    result.AddRange(selectedModule);
                }

                toQuery = result.AsQueryable();
            }

            return base.Filter(toQuery, args);
        }
    }
}
