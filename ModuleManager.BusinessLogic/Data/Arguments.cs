using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleManager.BusinessLogic.Data
{
    /// <summary>
    /// Generic class with shared data that can be used to filter anything.
    /// </summary>
    /// <remarks>
    /// This class cannot be instantiated, instead, it is used by the more conctrete argument classes. (e.g. ModuleAgruments)
    /// </remarks>
    public abstract class Arguments
    {
        /// <summary>
        /// Bevat kolomnamen voor sorteren, met aflopende prioriteit
        /// </summary>
        /// <remarks>
        /// string SortArgument, boolean Descending.
        /// </remarks>
        public Dictionary<string, bool> SortFor { get; set; }

        /// <summary>
        /// Algemene zoekterm
        /// </summary>
        public string Zoekterm { get; set; }
    }
}
