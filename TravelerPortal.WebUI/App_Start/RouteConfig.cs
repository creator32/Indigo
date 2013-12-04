using System.Web.Mvc;
using System.Web.Routing;

namespace TravelerPortal.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Main",
                url: string.Empty,
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

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
        }
    }
}