using System.Web.Mvc;
using System.Web.Routing;

namespace TravelerPortal.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Photogallery
            routes.MapRoute("AllAlbums",
                url: "photogallery",
                defaults: new { controller = "Photogallery", action = "Albums" }
            );
            routes.MapRoute("AlbumById",
                url: "album/{albumId}",
                defaults: new { controller = "Photogallery", action = "Album" }
            );
            #endregion

            #region Articles
            routes.MapRoute("AllArticles",
                url: "articles",
                defaults: new { controller = "Articles", action = "Articles" }
            );
            routes.MapRoute("ArticleById",
                url: "article/{articleId}",
                defaults: new { controller = "Articles", action = "Article" }
            );
            #endregion

            routes.MapRoute(null,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}