using System.Web.Optimization;

namespace GlassHouse{

    public class BundleConfig{

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles){

            bundles.Add( new ScriptBundle( "~/bundles/angular" ).Include(
                        "~/Scripts/angular/angular.js",
                        "~/Scripts/angular/angular-aria.js",
                        "~/Scripts/angular/angular-animate.js",
                        "~/Scripts/angular/angular-cookies.js",
                        "~/Scripts/angular/angular-loader.js",
                        "~/Scripts/angular/angular-messages.js",
                        "~/Scripts/angular/angular-mocks.js",
                        "~/Scripts/angular/angular-resource.js",
                        "~/Scripts/angular/angular-route.js",
                        "~/Scripts/angular/angular-sanitize.js",
                        "~/Scripts/angular/angular-scenario.js",
                        "~/Scripts/angular/angular-touch.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
                        "~/Scripts/jquery/jquery-2.1.1.js",
                        "~/Scripts/jquery/jquery.validate.js",
                        "~/Scripts/jquery/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery/jquery.unobtrusive-ajax.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/bootstrap" ).Include(
                        "~/Scripts/bootstrap/bootstrap.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/respond" ).Include(
                        "~/Scripts/respond/respond.js" ) );

            bundles.Add(new ScriptBundle( "~/bundles/glasshouse-anonymous" ).Include(
                        "~/Scripts/glasshouse/glasshouse.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/glasshouse-authorized" ).Include(
                        "~/Scripts/glasshouse/glasshouse.js",
                        "~/Scripts/glasshouse/glasshouse-nav.js" ) );

            bundles.Add( new StyleBundle( "~/Content/css" ).Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/glasshouse.css" ) );

        }

    }

}
