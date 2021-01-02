using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPIApplicaiton.Startup))]
namespace WebAPIApplicaiton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}