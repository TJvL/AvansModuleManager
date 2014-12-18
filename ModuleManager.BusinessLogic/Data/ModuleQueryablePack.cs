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
    public class ModuleQueryablePack : IQueryablePack<Module>
    {
        private readonly IQueryable<Module> _data;
        private readonly Arguments _args;

        public Arguments Args
        {
            get { return _args; }
        }

        public IQueryable<Module> Data
        {
            get { return _data; }
        }

        public ModuleQueryablePack(Arguments args, IQueryable<Module> data) 
        {
            this._data = data;
            this._args = args;
        }
    }
}
