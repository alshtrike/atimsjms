
using GlassHouse.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GlassHouse{

    public class GlassHouseConfig{


        // AKA "BundleConfig.cs"
        public static void RegisterBundles( BundleCollection bundles ){

            // jQuery
            bundles.Add(
                new ScriptBundle( "~/bundles/jquery" ).Include(
                    "~/Scripts/jquery/jquery-{version}.js" ) );
            bundles.Add(
                new ScriptBundle( "~/bundles/jqueryval" ).Include(
                    "~/Scripts/jquery/jquery.validate*"));

            // bootstrap
            bundles.Add(
                new ScriptBundle( "~/bundles/bootstrap" ).Include(
                  "~/Scripts/bootstrap/bootstrap.min.js",
                  "~/Scripts/bootstrap/respond.min.js"));
            bundles.Add(
                new StyleBundle( "~/Content/css").Include(
                  "~/Content/bootstrap.min.css",
                  "~/Content/site.css" ) );

            // angular
            bundles.Add(
                new ScriptBundle( "~/bundles/angular").Include(
                    "~/Scripts/angular/angular.min.js" ) );

            // GlassHouse
            bundles.Add(
                new ScriptBundle( "~/bundles/glasshouse").Include(
                    "~/Scripts/GlassHouse/glasshouse.js" ) );

            BundleTable.EnableOptimizations = true;

        }



        // AKA "RouteConfig.cs"

        public static void RegisterRoutes( RouteCollection routes){
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "GlassHouse", action = "Index", id = UrlParameter.Optional }
            );

        }



        // AKA "FilterConfig.cs"

        public static void RegisterGlobalFilters( GlobalFilterCollection filters ){
            filters.Add( new HandleErrorAttribute( ) );

        }



        // AKA "WebApiConfig.cs"

        public static void WebApiRegister( HttpConfiguration config ){

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

    }



    // AKA "Startup.Auth.cs"
    // @TODO: Make alternate Authentication modular
    public partial class Startup{

        int COOKIE_VALIDATE_TIME = 30;

        public void ConfigureAuth( IAppBuilder app ){
            app.CreatePerOwinContext( ApplicationDbContext.Create );
            app.CreatePerOwinContext<GlassHouseUserManager>( GlassHouseUserManager.Create );

            // ME LOVE COOKIES *nomnomnom*
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions{
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString( "/GlassHouseUser/User" ),
                    Provider = new CookieAuthenticationProvider{
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<GlassHouseUserManager, GlassHouseUser>(
                            validateInterval: TimeSpan.FromMinutes(COOKIE_VALIDATE_TIME ),
                            regenerateIdentity: ( manager, user ) => user.GenerateUserIdentityAsync( manager ) )
                    }
                }
            );

            app.UseExternalSignInCookie( DefaultAuthenticationTypes.ExternalCookie );

        }

    }



    // AKA "IdentityConfig.cs"

    public class GlassHouseUserManager: UserManager<GlassHouseUser>{

        public GlassHouseUserManager( IUserStore<GlassHouseUser> store )
            : base( store ){}

        public static GlassHouseUserManager Create( IdentityFactoryOptions<GlassHouseUserManager> options, IOwinContext context ){
            var manager = new GlassHouseUserManager( new UserStore<GlassHouseUser>( context.Get<ApplicationDbContext>( ) ) );

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<GlassHouseUser>( manager ){
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator{
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if( dataProtectionProvider != null ){
                manager.UserTokenProvider = new DataProtectorTokenProvider<GlassHouseUser>(
                    dataProtectionProvider.Create( "GlassHouse Identity" ) );
            }

            return manager;

        }

    }

}

