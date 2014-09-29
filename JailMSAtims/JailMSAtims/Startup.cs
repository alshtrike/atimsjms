using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JailMSAtims.Startup))]
namespace JailMSAtims
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
