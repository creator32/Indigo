using System.Web.Mvc;
using TravelerPortal.Data;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Areas.Admin.Views.Articles;

namespace TravelerPortal.WebUI.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Articles()
        {
            var model = new ArticlesVM
            {
                Articles = ArticlesService.GetAll()
            };
            return View(model);
        }

        public ActionResult EditArticle(int articleId)
        {
            var model = new EditArticleVM
            {
                Article = ArticlesService.GetById(articleId)
            };
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult SaveArticle(SaveArticleVM model)
        {
            var newArticle = new Article
            {
                Id = model.Article.Id,
                Name = model.Article.Name,
                IsActive = model.Article.IsActive
            };
            ArticlesService.Update(newArticle, model.BriefDescriptionContent, model.DetailedDescriptionContent);
            return RedirectToAction("EditArticle", new { articleId = model.Article.Id });
        }

        public ActionResult PreviewBriefArticle(int articleId)
        {
            var articles = new[] { 
                ArticlesService.GetById(articleId) 
            };
            return View("~/Views/Articles/Articles.cshtml", articles);
        }

        public ActionResult PreviewDetailedArticle(int articleId)
        {
            var article = ArticlesService.GetById(articleId);
            return View("~/Views/Articles/Article.cshtml", article);
        }
    }
}
