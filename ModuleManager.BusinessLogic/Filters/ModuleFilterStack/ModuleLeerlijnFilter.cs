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
    public class ModuleLeerlijnFilter : ModuleBaseFilter
    {
        public ModuleLeerlijnFilter(IFilter<Module> parent) : base(parent) { }
        public override IQueryable<Module> Filter(IQueryable<Module> toQuery, Arguments args)
        {
            if (args.LeerlijnFilter != null)
            {
                List<Module> result = new List<Module>();
                foreach (string arg in args.LeerlijnFilter)
                {
                    var selectedModule = 
                        from m in toQuery
                            where
                                m.Leerlijn.Any(
                                element => element.Naam.ToLower().Contains(arg.ToLower())
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
