using ModuleManager.BusinessLogic.Data;

namespace ModuleManager.Web.DataTablesMapping
{
    public class CustomDataTablesRequest : DefaultDataTablesRequest
    {
        public FilterSorterArguments Arguments { get; set; }
    }
}