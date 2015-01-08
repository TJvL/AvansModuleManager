using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using ModuleManager.BusinessLogic.Data;

namespace ModuleManager.Web.DataTablesMapping
{
    public class CustomDataTablesBinder : DataTablesBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return Bind(controllerContext, bindingContext, typeof(CustomDataTablesRequest));
        }

        protected override void MapAditionalProperties(IDataTablesRequest requestModel, NameValueCollection requestParameters)
        {
            var model = (CustomDataTablesRequest)requestModel;

            var competenties = Get<string>(requestParameters, "filter[competentie][]").Split(',');
            var fases = Get<string>(requestParameters, "filter[fases][]").Split(',');
            var tags = Get<string>(requestParameters, "filter[tags][]").Split(',');

            var arguments = new FilterSorterArguments
            {
                CompetentieFilters = competenties, 
                FaseFilters = fases, 
                TagFilters = tags
            };

            model.Arguments = arguments;

            //var blokken = Array.ConvertAll(Get<string>(requestParameters, "filter[blok][]").Split(','), int.Parse);
            //var leerjaar = Get<string>(requestParameters, "filter[leerjaar]");
        }
    }
}