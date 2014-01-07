using System.Web.Mvc;
using TravelerPortal.WebUI.Models.Comments;
using TravelerPortal.WebUI.Views.Comments;

namespace TravelerPortal.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult Comments()
        {
            var model = new CommentsVM();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult AddComment(int areaId, int entityId, AddComment_Post_Req model)
        {
            return Json(string.Empty);
        }
    }
}
