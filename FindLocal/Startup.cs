using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindLocal.Startup))]
namespace FindLocal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
