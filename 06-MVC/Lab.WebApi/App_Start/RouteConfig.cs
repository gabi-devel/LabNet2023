using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab.WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Sirve si creo un controlador como MVC
            //routes.MapRoute(
            //    name: "PruebaApiRoute",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "PruebaApi", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
