using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnxProject_Franco.Startup))]
namespace KnxProject_Franco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
