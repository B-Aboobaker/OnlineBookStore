using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBookStore.Startup))]
namespace OnlineBookStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
