using ModuleManager.BusinessLogic.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    /// <summary>
    /// Klasse om filters te vervangen zoalng er geen concrete implementatie (nodig) is.
    /// </summary>
    public class DummyFilterService : IFilterService
    {
        /// <summary>
        /// passthrough
        /// </summary>
        /// <param name="toQuery">Een willekeuring queryable Pack</param>
        /// <returns>Alle data van het queryablepack</returns>
        public IEnumerable Filter(IQueryablePack toQuery)
        {
            return toQuery.GetData() as IEnumerable;
        }
    }
}
