using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeeKang.Startup))]
namespace GeeKang
{
    public partial class Startup
    { 
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
