using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumatorAndHttpHandler.Startup))]
namespace SumatorAndHttpHandler
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
