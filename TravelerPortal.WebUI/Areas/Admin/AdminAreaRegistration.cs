using System.Web.Mvc;

namespace TravelerPortal.WebUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("AdminMain",
                "admin",
                new { controller = "Home", action = "Index" }
            );
        }
    }
}
