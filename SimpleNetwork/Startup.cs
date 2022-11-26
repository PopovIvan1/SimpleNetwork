using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleNetwork.Startup))]
namespace SimpleNetwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
