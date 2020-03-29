using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly_new.Startup))]
namespace Vidly_new
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
