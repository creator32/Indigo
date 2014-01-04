using System;

namespace TravelerPortal.WebUI.Views.Events
{
    public class EventVM
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int AmountOfDays { get; set; }
        public int Price_UAH_ { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}