using System.Web;

namespace TravelerPortal.WebUI.Infrastructure
{
    public static class ClientContext
    {
        private static HttpContext httpContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        private static HttpCookieCollection cookies
        {
            get
            {
                return httpContext.Request.Cookies;
            }
        }

        public static int TimeZoneOffsetInMinutes
        {
            get
            {
                return int.Parse(cookies["timeZoneOffsetInMinutes"].Value);
            }
        }
    }
}