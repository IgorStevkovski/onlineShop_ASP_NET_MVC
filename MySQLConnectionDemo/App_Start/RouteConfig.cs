using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MySQLConnectionDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //koga definiras svoi specificni ruti, mora najgore ovde da se vo kodot, posto dolnite se opsti i se' fakjaat
            //routes.MapRoute(
            //    name: "Kreiraj produkt",
            //    url: "create/product",
            //    defaults: new { controller = "Category", action = "AddProduct" }
            //);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "Category", action = "BelaTehnika", id=UrlParameter.Optional}
            );

        }
    }
}
