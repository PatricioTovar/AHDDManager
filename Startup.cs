using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AHDDManager.Startup))]
namespace AHDDManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
