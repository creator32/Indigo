namespace TravelerPortal.WebUI.Areas.Admin.Views.Articles
{
    public class SaveArticleVM
    {
        public class _Article
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
        public _Article Article { get; set; }
        public string BriefDescriptionContent { get; set; }
        public string DetailedDescriptionContent { get; set; }
    }
}