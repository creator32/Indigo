using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class NewsController : Controller
    {
        private NewsService newsService;

        public NewsController()
        {
            newsService = new NewsService();
            ViewBag.ActiveMainMenuItemTitle = "Новости";
        }

        public ActionResult NewsMiddle()
        {
            var newsList = newsService.GetActive();
            return View(newsList);
        }

        [ChildActionOnly]
        public PartialViewResult NewsSidebar()
        {
            var newsList = newsService.GetActive();
            return PartialView(newsList);
        }

        public ActionResult News(int newsId)
        {
            var news = newsService.GetById(newsId);
            return View(news);
        }
    }
}