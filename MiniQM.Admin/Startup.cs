using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniQM.Admin.Startup))]
namespace MiniQM.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
