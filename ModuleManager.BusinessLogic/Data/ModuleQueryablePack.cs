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
        public ModuleArguments Args { get; private set; }
        public IQueryable<Module> Data { get; private set; }

        public ModuleQueryablePack(IQueryable<Module> data, ModuleArguments args) 
        {
            Args = args;
            Data = data;
        }
    }
}
