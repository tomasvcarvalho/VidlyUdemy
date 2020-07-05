using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlySite.Startup))]
namespace VidlySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
