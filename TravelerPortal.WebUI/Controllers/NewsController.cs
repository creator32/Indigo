using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class NewsController : Controller
    {
        public NewsController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Новости";
        }

        public ActionResult NewsMiddle()
        {
            var newsList = NewsService.GetActiveNews();
            return View(newsList);
        }

        [ChildActionOnly]
        public PartialViewResult NewsSidebar()
        {
            var newsList = NewsService.GetActiveNews();
            return PartialView(newsList);
        }

        public ActionResult News(int newsId)
        {
            var news = NewsService.GetNewsById(newsId);
            return View(news);
        }
    }
}