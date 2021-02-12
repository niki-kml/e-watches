using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_Watch.Startup))]
namespace e_Watch
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
