using ModuleManager.BusinessLogic.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    public class DummyFilterService : IFilterService
    {
        public IEnumerable Filter(IQueryablePack toQuery)
        {
            return toQuery as IEnumerable;
        }
    }
}
