using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Filippov.Startup))]
namespace Filippov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
