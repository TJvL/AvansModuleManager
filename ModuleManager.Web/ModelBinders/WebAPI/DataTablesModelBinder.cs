using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using ModuleManager.BusinessLogic.Data;

namespace ModuleManager.Web.ModelBinders.WebAPI
{
    public class DataTablesModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var arguments = new Arguments();

            var content = actionContext.Request.Content.ReadAsStringAsync().Result;

            bindingContext.Model = arguments;

            return true;
        }
    }
}