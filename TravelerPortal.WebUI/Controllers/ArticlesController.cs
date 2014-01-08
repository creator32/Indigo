using System.Configuration;
using System.Web.Mvc;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Infrastructure;

namespace TravelerPortal.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        private static readonly ArticlesService articlesService;
        private static readonly string VKAppId;
        private static readonly string FBAppId;

        static ArticlesController()
        {
            VKAppId = ConfigurationManager.AppSettings["social:VKAppId"];
            FBAppId = ConfigurationManager.AppSettings["social:FBAppId"];
            articlesService = new ArticlesService();
        }

        public ArticlesController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Статьи";
            ViewBag.AreaId = SiteAreas.Article;
        }

        public ActionResult Articles()
        {
            var articles = articlesService.GetActive();
            return View(articles);
        }

        public ActionResult Article(int articleId)
        {
            ViewBag.VKAppId = VKAppId;
            ViewBag.FBAppId = FBAppId;
            var article = articlesService.GetById(articleId);
            return View(article);
        }
    }
}