using ModuleManager.BusinessLogic.Interfaces.Services;
using ModuleManager.BusinessLogic.Interfaces.Sorters;
using ModuleManager.BusinessLogic.Sorters;
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
    /// Sorting class for use with Modules
    /// </summary>
    public class ModuleSorterService : ISorterService<DomainDAL.Module>
    {
        ISorter<DomainDAL.Module> moduleSorterStrategy;

        /// <summary>
        /// Constructor: Builds the contained Strategy
        /// </summary>
        public ModuleSorterService() 
        {
            moduleSorterStrategy = new ModulePassiveSorter();

            //Build Reflection Here
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.IsClass && t.Namespace == "ModuleManager.BusinessLogic.Sorters.ModuleSorterStack" && !t.IsDefined(typeof(CompilerGeneratedAttribute), false)
                        select t;
            Type[] typeArgs = { typeof(ISorter<DomainDAL.Module>) };
            foreach (Type t in types) 
            {
                var ctor = t.GetConstructor(typeArgs);
                if (ctor != null) 
                {
                    object[] parameters = { moduleSorterStrategy };
                    moduleSorterStrategy = ctor.Invoke(parameters) as ISorter<DomainDAL.Module>;
                }
            }
        }

        /// <summary>
        /// Operates the sorting on the input List of Modules
        /// </summary>
        /// <param name="qPack">Pack with Data and required Arguments</param>
        /// <returns>List of Sorted Modules</returns>
        public IEnumerable<DomainDAL.Module> Sort(Interfaces.IQueryablePack<DomainDAL.Module> qPack)
        {
            return moduleSorterStrategy.Sort(qPack.Data, qPack.Args).AsEnumerable();
        }
    }
}
