using System.Web.Mvc;
using System.Web.Routing;

namespace TravelerPortal.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                url: "photogallery",
                defaults: new { controller = "Photogallery", action = "Albums" }
            );

            routes.MapRoute(null,
                url: "album/{albumId}",
                defaults: new { controller = "Photogallery", action = "Album" }
            );

            routes.MapRoute(null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}