using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ModuleManager.Web.Startup))]
namespace ModuleManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
      
    }
}