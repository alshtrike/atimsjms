using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AtimsWeb {

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            // Default API Routes
            //   Note: Many API's will override this and declare their own
            //   on a per api-function basis. This file may be rendered
            //   unnecesary.
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
