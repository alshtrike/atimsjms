using System.Web.Mvc;

namespace GlassHouse{

    public class FilterConfig{

        public static void RegisterGlobalFilters( GlobalFilterCollection filters ){
            filters.Add( new HandleErrorAttribute( ) );

        }

    }

}
