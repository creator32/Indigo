﻿using System.Web.Mvc;
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
        }
    }
}