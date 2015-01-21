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
    public class ModuleFaseNamenFilter : ModuleBaseFilter
    {
        public ModuleFaseNamenFilter(IFilter<Module> parent) : base(parent) { }
        public override IQueryable<Module> Filter(IQueryable<Module> toQuery, ModuleFilterSorterArguments args)
        {
            if (args.FaseFilters != null && args.FaseFilters.Count > 0)
            {
                List<Module> result = new List<Module>();
                foreach (string arg in args.FaseFilters)
                {
                    var selectedModule = 
                        from m in toQuery
                            where
                                m.FaseModules.Any(
                                element => (element.FaseNaam ?? "").ToLower().Contains((arg ?? "").ToLower())
                                )
                        select m;

                    result.AddRange(selectedModule.Where(x => !result.Contains(x)));
                }

                toQuery = result.AsQueryable();
            }

            return base.Filter(toQuery, args);
        }
    }
}
