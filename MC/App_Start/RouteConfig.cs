using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tmodels", action = "Cycles", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "tmodel",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "tmodels", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
