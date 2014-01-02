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
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );

            #region Photogallery
            routes.MapRoute("AllAlbums",
                url: "photogallery",
                defaults: new { controller = "Photogallery", action = "Albums" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("AlbumById",
                url: "album/{albumId}",
                defaults: new { controller = "Photogallery", action = "Album" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion

            #region Articles
            routes.MapRoute("AllArticles",
                url: "articles",
                defaults: new { controller = "Articles", action = "Articles" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("ArticleById",
                url: "article/{articleId}",
                defaults: new { controller = "Articles", action = "Article" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion

            #region News
            routes.MapRoute("AllNewsSidebar",
                url: "news/sidebar",
                defaults: new { controller = "News", action = "NewsSidebar" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("AllNews",
                url: "news",
                defaults: new { controller = "News", action = "NewsMiddle" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("NewsById",
                url: "news/{newsId}",
                defaults: new { controller = "News", action = "News" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion

            #region Travels
            routes.MapRoute("AllTravels",
                url: "travels",
                defaults: new { controller = "Travels", action = "Travels" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("TravelById",
                url: "travel/{travelId}",
                defaults: new { controller = "Travels", action = "Travel" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion

            #region Events
            routes.MapRoute("AllEventsSidebar",
                url: "events/sidebar",
                defaults: new { controller = "Events", action = "EventsSidebar" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            routes.MapRoute("EventCalendar",
                url: "events/calendar",
                defaults: new { controller = "Events", action = "Calendar" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion

            #region Books
            routes.MapRoute("AllBooks",
                url: "books",
                defaults: new { controller = "Books", action = "Books" },
                namespaces: new[] { "TravelerPortal.WebUI.Controllers" }
            );
            #endregion
        }
    }
}