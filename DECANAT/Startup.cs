using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DECANAT.Startup))]
namespace DECANAT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
