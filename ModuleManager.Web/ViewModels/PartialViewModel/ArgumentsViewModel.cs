using System.Collections.Generic;

namespace ModuleManager.Web.ViewModels.PartialViewModel
{
    public class ArgumentsViewModel
    {
        public int Draw { get; set; }
        public ICollection<ColumnViewModel> Columns { get; set; }
    }
}