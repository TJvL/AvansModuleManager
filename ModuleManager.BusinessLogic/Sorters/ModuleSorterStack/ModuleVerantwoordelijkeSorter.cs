﻿using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Interfaces.Sorters;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Sorters.ModuleSorterStack
{
    public class ModuleVerantwoordelijkeSorter : ModuleBaseSorter
    {
        public ModuleVerantwoordelijkeSorter(ISorter<Module> parent) : base(parent) { }

        public override IQueryable<Module> Sort(IQueryable<Module> toSort, Arguments args) 
        {
            if (args.SortBy.Equals("Verantwoordelijke")) 
            {
                if (args.SortDesc) 
                {
                    toSort = toSort.OrderByDescending(element => element.Verantwoordelijke);
                }
                else 
                {
                    toSort = toSort.OrderBy(element => element.Verantwoordelijke); 
                }
            }

            return base.Sort(toSort, args);
        }
    }
}
