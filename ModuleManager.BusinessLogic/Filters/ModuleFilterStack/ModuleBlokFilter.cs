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
    public class ModuleBlokFilter : ModuleBaseFilter
    {
        public ModuleBlokFilter(IFilter<Module> parent) : base(parent) { }
        public override IQueryable<Module> Filter(IQueryable<Module> toQuery, Arguments args)
        {
            if (args.Blokken != null)
            {
                List<Module> result = new List<Module>();
                foreach (int arg in args.Blokken)
                {
                    var selectedModule = 
                        from m in toQuery
                            where
                                m.FaseModules.Any(
                                element => element.Blok.Equals(""+arg)
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
