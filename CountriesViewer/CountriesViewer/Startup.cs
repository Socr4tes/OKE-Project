using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CountriesViewer.Startup))]
namespace CountriesViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
