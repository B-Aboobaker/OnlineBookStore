using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineBookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddToCart",
                url: "Book/AddToCart/{id}",
                defaults: new { controller = "Book", action = "AddToCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "Cart/{action}",
                defaults: new { controller = "Cart", action = "Index" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
