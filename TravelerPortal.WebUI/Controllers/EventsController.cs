using System.Linq;
using System.Web.Mvc;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Views.Events;

namespace TravelerPortal.WebUI.Controllers
{
    public class EventsController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult EventsSidebar()
        {
            var eventsList = EventsService.GetActive().OrderByDescending(e => e.StartDate).ToArray();
            return PartialView(eventsList);
        }

        public ActionResult Schedule()
        {
            ViewBag.ActiveMainMenuItemTitle = "Расписание";
            var activeEvents = EventsService.GetActive();
            var model = new ScheduleVM();
            foreach (var _event in activeEvents)
            {
                model.Events.Add(new EventVM()
                {
                    StartDate = _event.StartDate,
                    EndDate = _event.EndDate,
                    Price_UAH_ = _event.Price_UAH_,
                    Name = _event.Name,
                    AmountOfDays = (_event.EndDate - _event.StartDate).Days,
                    Url = Url.RouteUrl("TravelById", new { travelId = _event.TravelId })
                });
            }
            return View(model);
        }
    }
}
