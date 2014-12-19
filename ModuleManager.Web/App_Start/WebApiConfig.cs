using System.Web.Http;

namespace ModuleManager.Web
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
        }
    }
}