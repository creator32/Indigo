
namespace TravelerPortal.WebUI.Views.Comments
{
    public class CommentVM
    {
        public class UserVM
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Thumbnail { get; set; }
        }

        public string Text { get; set; }
        public UserVM User { get; set; }
    }
}