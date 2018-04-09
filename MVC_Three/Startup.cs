using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Three.Startup))]
namespace MVC_Three
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
