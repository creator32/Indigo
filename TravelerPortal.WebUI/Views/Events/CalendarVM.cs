using System.Collections.Generic;

namespace TravelerPortal.WebUI.Views.Events
{
    public class CalendarVM
    {
        public List<CalendarEventVM> Events { get; set; }

        public CalendarVM()
        {
            Events = new List<CalendarEventVM>();
        }
    }
}