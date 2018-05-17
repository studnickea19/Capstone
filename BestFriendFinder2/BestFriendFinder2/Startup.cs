using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BestFriendFinder2.Startup))]
namespace BestFriendFinder2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
