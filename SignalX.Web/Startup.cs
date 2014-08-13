using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalX.Web.Startup))]
namespace SignalX.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var configuration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };
            app.MapSignalR(configuration);
        }
    }
}
