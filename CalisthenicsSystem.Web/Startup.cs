using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CalisthenicsSystem.Web.Startup))]
namespace CalisthenicsSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
