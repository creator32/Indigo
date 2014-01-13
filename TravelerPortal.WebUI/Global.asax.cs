using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TravelerPortal.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            var isThereTimezoneCookieOnClient = (Request.Cookies["timeZoneOffset"] != null);
            if (!isThereTimezoneCookieOnClient && Request.Url.AbsolutePath != new UrlHelper(Request.RequestContext).RouteUrl("TimezoneCookieAdder"))
            {
                var newUrl = string.Format(
                    "{0}?{1}={2}",
                    new UrlHelper(Request.RequestContext).RouteUrl("TimezoneCookieAdder"),
                    "redirectUrl",
                    Request.Url.AbsoluteUri
                );
                Response.Redirect(newUrl, true);
            }
        }
    }
}