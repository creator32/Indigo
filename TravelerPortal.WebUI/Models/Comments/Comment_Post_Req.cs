
namespace TravelerPortal.WebUI.Models.Comments
{
    public class Comment_Post_Req
    {
        public class User_Post_Req
        {
            public string FBId { get; set; }
            public string VKId { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Thumbnail { get; set; }
        }

        public string Text { get; set; }
        public User_Post_Req User { get; set; }
    }
}