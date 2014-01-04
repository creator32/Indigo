using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class TravelsController : Controller
    {
        private TravelsService travelsService;

        public TravelsController()
        {
            travelsService = new TravelsService();
            ViewBag.ActiveMainMenuItemTitle = "Программы";
        }

        public ActionResult Travels()
        {
            var travels = travelsService.GetActive();
            return View(travels);
        }

        public ActionResult Travel(int travelId)
        {
            var travel = travelsService.GetById(travelId);
            return View(travel);
        }
    }
}
