using ModuleManager.BusinessLogic.Interfaces;
using ModuleManager.DomainDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Implementation of IQueryablePack that allows the filtering, sorting and exporting of Modules.
    /// </summary>
    /// <remarks>
    /// This implementation offers a collection of Data together with Arguments. The arguments are used to manipulate the data into a manageable chunk of data.
    /// </remarks>
    public class ModuleQueryablePack : IQueryablePack
    {
        ModuleArguments args;
        IQueryable<Module> data = new List<Module>() as IQueryable<Module>;

        /// <summary>
        /// Get the arguments that were passed along in this object.
        /// </summary>
        /// <returns>An arguments object containing relevant filtering and sorting info.</returns>
        public Arguments GetArguments()
        {
            return args;
        }

        /// <summary>
        /// Set arguments to pass along with this object.
        /// </summary>
        /// <param name="args">Arguments to be passed along with the data.</param>
        public void SetArguments(ModuleArguments args)
        {
            this.args = args;
        }

        /// <summary>
        /// Get the modules that ware passed along in this object.
        /// </summary>
        /// <returns>All data to be queried.</returns>
        public IQueryable<Module> GetData()
        {
            return data;
        }

        /// <summary>
        /// Set the modules to be passed along.
        /// </summary>
        /// <param name="data">A list of modules.</param>
        public void SetData(IQueryable<Module> data)
        {
            this.data = data;
        }
    }
}
