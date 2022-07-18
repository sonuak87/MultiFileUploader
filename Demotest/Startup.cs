using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demotest.Startup))]
namespace Demotest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
