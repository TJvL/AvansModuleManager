using ModuleManager.DomainDAL;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ModuleListViewModel
    {

        public ICollection<ModuleViewModel> Modules { get; set; }

        public int RecordsFiltered { get { return Modules.Count; } }

        public int RecordsTotal { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="recordsTotal">Totaal aantal modules in de datasource"</param>
        public ModuleListViewModel(int recordsTotal)
        {
            RecordsTotal = recordsTotal;
        }

        public void AddModules(IEnumerable<Module> moduleList)
        {
            Modules = moduleList
                .Select(Mapper.Map<Module, ModuleViewModel>)
                .ToList();
        }
    }
}