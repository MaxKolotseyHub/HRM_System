using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRM_System_UI.Startup))]
namespace HRM_System_UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
