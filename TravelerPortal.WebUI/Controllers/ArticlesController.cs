﻿using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        public ArticlesController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Статьи";
        }

        public ActionResult Articles()
        {
            var articles = ArticlesService.GetActiveArticles();
            return View(articles);
        }

        public ActionResult Article(int articleId)
        {
            var article = ArticlesService.GetArticleById(articleId);
            return View(article);
        }
    }
}