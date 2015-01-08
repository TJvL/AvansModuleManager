using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;

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

            // var competenties = Get<>()


            // myModel.MyCustomProp = Get<string>(requestParameters, "myCustomProp");
        }

        private List<string> GetCompetentieFilters(NameValueCollection collection)
        {
            return null;
        }
    }
}