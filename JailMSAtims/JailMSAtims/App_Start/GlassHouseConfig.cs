
using GlassHouse.Models;
using Owin;
using System;
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
                    "~/Scripts/jquery/jquery.validate*") );

            // bootstrap
            bundles.Add(
                new ScriptBundle( "~/bundles/bootstrap" ).Include(
                  "~/Scripts/bootstrap/bootstrap.min.js",
                  "~/Scripts/bootstrap/respond.min.js") );
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
            filters.Add( new System.Web.Mvc.AuthorizeAttribute( ) );

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

}

