using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day1Homework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "skilltree",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Day1Homework.Controllers" }
            );

            routes.MapRoute(
                name: "Root_default",
                url: "skilltree/{controller}/{action}/{yyyy}/{mm}",
                defaults: new { controller = "Home", action = "Index", yyyy = UrlParameter.Optional,
                mm = UrlParameter.Optional
                },
                namespaces: new[] { "Day1Homework.Controllers" }
            );
        }
    }
}
