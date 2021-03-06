﻿using System.Web.Mvc;

namespace TravelerPortal.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("AdminMain",
                "admin",
                new { controller = "Articles", action = "Articles" }
            );
            #region Article
            context.MapRoute("AdminEditArticle",
                "admin/article/{articleId}/edit",
                new { controller = "Articles", action = "EditArticle" }
            );

            context.MapRoute("AdminSaveArticle",
                "admin/article/{articleId}/save",
                new { controller = "Articles", action = "SaveArticle" }
            );

            context.MapRoute("AdminPreviewBriefArticle",
                "admin/article/{articleId}/preview-brief",
                new { controller = "Articles", action = "PreviewBriefArticle" }
            );

            context.MapRoute("AdminPreviewDetailedArticle",
                "admin/article/{articleId}/preview-detailed",
                new { controller = "Articles", action = "PreviewDetailedArticle" }
            );
            #endregion
            context.MapRoute("AdminBooks",
                "admin/books/{action}",
                new { controller = "Books", action = "Index" }
            );
            context.MapRoute("AdminNews",
                "admin/news/{action}",
                new { controller = "News", action = "Index" }
            );
        }
    }
}
