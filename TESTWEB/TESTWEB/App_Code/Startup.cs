using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TESTWEB.Startup))]
namespace TESTWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
