using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute( typeof( GlassHouse.Startup ) )]
namespace GlassHouse{

    public partial class Startup{

        public void Configuration( IAppBuilder app ){
            ConfigureAuth( app );
        }

    }

}
