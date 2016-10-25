using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanetVetWebPortal.Startup))]
namespace PlanetVetWebPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
