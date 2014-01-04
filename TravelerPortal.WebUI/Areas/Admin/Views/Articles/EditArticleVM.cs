using TravelerPortal.Data;

namespace TravelerPortal.WebUI.Areas.Admin.Views.Articles
{
    public class EditArticleVM
    {
        public Article Article { get; set; }
        public string BriefContent { get; set; }
        public string DetailedContent { get; set; }
    }
}