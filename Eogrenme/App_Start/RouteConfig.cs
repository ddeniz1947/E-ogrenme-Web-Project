using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eogrenme
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Reg", "reg", new { controller = "Register", action = "Reg", id = UrlParameter.Optional });
            routes.MapRoute("Login" , "", new { controller = "Login", action = "Auth", id = UrlParameter.Optional });
        }
    }
}
