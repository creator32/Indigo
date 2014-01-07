
using System.Collections.Generic;
namespace TravelerPortal.WebUI.Views.Comments
{
    public class CommentsVM
    {
        public List<CommentVM> Comments { get; set; }

        public CommentsVM()
        {
            Comments = new List<CommentVM>();
        }
    }
}