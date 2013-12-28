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

        public ActionResult Calendar()
        {
            var activeEvents = EventsService.GetActive();
            var model = new CalendarVM();
            foreach (var _event in activeEvents)
            {
                model.Events.Add(new CalendarEventVM()
                {
                    Date = _event.StartDate,
                    Url = Url.RouteUrl("TravelById", new { travelId = _event.TravelId })
                });
            }
            return View(model);
        }
    }
}
