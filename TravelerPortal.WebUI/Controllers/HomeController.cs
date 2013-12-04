using System.Web.Mvc;

namespace TravelerPortal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Главная";
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}