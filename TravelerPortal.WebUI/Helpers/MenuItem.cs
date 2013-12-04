
namespace TravelerPortal.WebUI.Helpers
{
    public class MenuItem
    {
        public string Title { get; private set; }
        public string Url { get; private set; }

        public MenuItem(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}