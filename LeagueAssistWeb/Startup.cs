using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueAssistWeb.Startup))]
namespace LeagueAssistWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
