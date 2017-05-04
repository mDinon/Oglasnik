using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oglasnik.Web.Startup))]
namespace Oglasnik.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
