using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WVEDISC.Startup))]
namespace WVEDISC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
