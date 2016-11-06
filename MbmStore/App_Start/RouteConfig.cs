using System.Web.Mvc;
using System.Web.Routing;

namespace MbmStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: null,
               url: "{controller}",
               defaults: new { controller = "Catalogue", action = "Index", category = (string)null, page = 1 }
            );

            routes.MapRoute(
               name: null,
               url: "{controller}/Page{page}",
               defaults: new { controller = "Catalogue", action = "Index", category = (string)null },
               constraints: new { page = @"\d+" }
           );

            routes.MapRoute(
               name: null,
               url: "Catalogue/{category}",
               defaults: new { controller = "Catalogue", action = "Index", page = 1 }
           );

            routes.MapRoute(
               name: null,
               url: "{controller}/{category}/Page{page}",
               defaults: new { controller = "Catalogue", action = "Index" },
               constraints: new { page = @"\d+" }
           );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Catalogue", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
