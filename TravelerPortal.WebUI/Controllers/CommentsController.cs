using System.Linq;
using System.Web.Mvc;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Models.Comments;
using TravelerPortal.WebUI.Views.Comments;

namespace TravelerPortal.WebUI.Controllers
{
    public class CommentsController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult Comments(int areaId, int entityId)
        {
            var dbComments = CommentsService.GetActive(areaId, entityId, fieldsToInclude: "User");
            var model = new CommentsVM()
            {
                Comments = dbComments.Select(c => new CommentVM()
                {
                    Text = c.Text,
                    Created = c.Created,
                    User = new CommentVM.UserVM()
                    {
                        FirstName = c.User.FirstName,
                        LastName = c.User.LastName,
                        Thumbnail = c.User.Thumbnail,
                    }
                }).ToList()
            };
            return PartialView(model);
        }

        public JsonResult AddComment(int areaId, int entityId, AddComment_Post_Req model)
        {
            var commentToAdd = new Data.Comment()
            {
                AreaId = areaId,
                EntityId = entityId,
                IsActive = true,
                Text = model.Comment.Text
            };
            var userToAddCommentTo = new Data.User()
            {
                FBId = model.Comment.User.FBId,
                VKId = model.Comment.User.VKId,
                FirstName = model.Comment.User.FirstName,
                LastName = model.Comment.User.LastName,
                Thumbnail = model.Comment.User.Thumbnail
            };
            CommentsService.Add(commentToAdd, userToAddCommentTo);
            return Json(string.Empty);
        }
    }
}
