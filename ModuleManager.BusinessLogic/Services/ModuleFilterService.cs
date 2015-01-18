using ModuleManager.BusinessLogic.Data;
using ModuleManager.BusinessLogic.Filters;
using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.BusinessLogic.Interfaces.Filters;
using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Services
{
    /// <summary>
    /// Filtering class for use with Modules
    /// </summary>
    public class ModuleFilterService : IFilterService<DomainDAL.Module>
    {
        IFilter<DomainDAL.Module> moduleFilterStrategy;

        /// <summary>
        /// Constructor: Builds the contained Strategy
        /// </summary>
        public ModuleFilterService() 
        {
            moduleFilterStrategy = new ModulePassiveFilter();
            
            // Build Reflection Here
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.IsClass && t.Namespace == "ModuleManager.BusinessLogic.Filters.ModuleFilterStack" && !t.IsDefined(typeof (CompilerGeneratedAttribute), false)
                        select t;
            Type[] typeArgs = {typeof(IFilter<DomainDAL.Module>)};

            foreach (Type t in types) 
            {
                var ctor = t.GetConstructor(typeArgs);
                if (ctor != null)
                {
                    object[] parameters = { moduleFilterStrategy };
                    moduleFilterStrategy = ctor.Invoke(parameters) as IFilter<DomainDAL.Module>;
                }
            }
        }

        /// <summary>
        /// Operates the filtering on the input List of Modules
        /// </summary>
        /// <param name="qPack">Pack with Data and required Arguments</param>
        /// <returns>List of Filtered Modules</returns>
        public IEnumerable<DomainDAL.Module> Filter(IQueryablePack<DomainDAL.Module> qPack)
        {
            return moduleFilterStrategy.Filter(qPack.Data, qPack.Args) as IEnumerable<DomainDAL.Module>;
        }
    }
}
