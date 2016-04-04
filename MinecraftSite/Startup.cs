using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinecraftSite.Startup))]
namespace MinecraftSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
