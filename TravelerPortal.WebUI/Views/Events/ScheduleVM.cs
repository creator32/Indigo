using System.Collections.Generic;

namespace TravelerPortal.WebUI.Views.Events
{
    public class ScheduleVM
    {
        public List<EventVM> Events { get; set; }

        public ScheduleVM()
        {
            Events = new List<EventVM>();
        }
    }
}