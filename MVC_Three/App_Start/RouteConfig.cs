using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Three
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //route is now defined in controller via this approach (see movie controller)
            routes.MapMvcAttributeRoutes(); //a better way to manage routes


            /*
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate", year = 2018, month = 1 },
                // new { year = @"\d{4}", month = @"\d{2}"  } //constraints the param entered to 4, 2 digits respectively.
                new { year = @"2015|2016", month = @"\d{2}" } //constraints year to 2015-2016
                );
                */


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
