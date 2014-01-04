using System.Web.Mvc;
using TravelerPortal.Data;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Areas.Admin.Views.Articles;

namespace TravelerPortal.WebUI.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticlesService articlesService;

        public ArticlesController()
        {
            articlesService = new ArticlesService();
        }

        public ActionResult Articles()
        {
            var model = new ArticlesVM
            {
                Articles = articlesService.GetAll()
            };
            return View(model);
        }

        public ActionResult EditArticle(int articleId)
        {
            var model = new EditArticleVM();
            model.Article = articlesService.GetById(articleId);
            model.BriefContent = articlesService.ReadContent(model.Article, ContentType.Brief);
            model.DetailedContent = articlesService.ReadContent(model.Article, ContentType.Detailed);
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
            articlesService.Update(newArticle, model.BriefDescriptionContent, model.DetailedDescriptionContent);
            return RedirectToAction("EditArticle", new { articleId = model.Article.Id });
        }

        public ActionResult PreviewBriefArticle(int articleId)
        {
            var articles = new[] { 
                articlesService.GetById(articleId) 
            };
            return View("~/Views/Articles/Articles.cshtml", articles);
        }

        public ActionResult PreviewDetailedArticle(int articleId)
        {
            var article = articlesService.GetById(articleId);
            return View("~/Views/Articles/Article.cshtml", article);
        }
    }
}
