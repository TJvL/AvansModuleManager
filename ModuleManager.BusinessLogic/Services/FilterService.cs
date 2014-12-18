using ModuleManager.BusinessLogic.Data;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    public class FilterService
    {
        public IQueryable<Module> FilterModules(ModuleQueryablePack toFilter) 
        {
            //filter the stuff, and return it;
            throw new NotImplementedException();
        }
    }
}
