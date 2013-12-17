using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class TravelsController : Controller
    {
        public TravelsController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Программы";
        }

        public ActionResult Travels()
        {
            var travels = TravelsService.GetActive();
            return View(travels);
        }

        public ActionResult Travel(int travelId)
        {
            var travel = TravelsService.GetById(travelId);
            return View(travel);
        }
    }
}
