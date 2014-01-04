using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticlesService articlesService;

        public ArticlesController()
        {
            articlesService = new ArticlesService();
            ViewBag.ActiveMainMenuItemTitle = "Статьи";
        }

        public ActionResult Articles()
        {
            var articles = articlesService.GetActive();
            return View(articles);
        }

        public ActionResult Article(int articleId)
        {
            var article = articlesService.GetById(articleId);
            return View(article);
        }
    }
}