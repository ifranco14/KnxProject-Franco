using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnxProject_Franco.Web.Startup))]
namespace KnxProject_Franco.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
