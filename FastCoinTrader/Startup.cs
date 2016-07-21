using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FastCoinTrader.Startup))]
namespace FastCoinTrader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
