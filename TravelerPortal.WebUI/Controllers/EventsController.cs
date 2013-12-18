using System.Linq;
using System.Web.Mvc;
using TravelerPortal.Services;

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
    }
}
