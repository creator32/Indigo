using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TravelerPortal.Data;
using TravelerPortal.Shared;

namespace TravelerPortal.Services
{
    public static class NewsService
    {
        public static string pathToNews;

        static NewsService()
        {
            pathToNews = ConfigurationManager.AppSettings["pathToNews"];
        }

        public static string ReadContentOfNews(News news, ContentType contentType)
        {
            var nameOfFile = (contentType == ContentType.Brief) ? news.BriefDescriptionPath : news.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToNews, nameOfFile));
            return File.ReadAllText(pathToFile, Encoding.UTF8);
        }

        private static void WriteContentOfNews(News news, ContentType ContentType, string newContent)
        {
            var nameOfFile = (ContentType == ContentType.Brief) ? news.BriefDescriptionPath : news.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToNews, nameOfFile));
            File.WriteAllText(pathToFile, newContent, Encoding.UTF8);
        }

        public static News[] GetActiveNews()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.News.Where(n => n.IsActive).ToArray();
            });
        }

        public static News[] GetAllNews()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.News.ToArray();
            });
        }

        public static News GetNewsById(int id)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return GetNewsById(db, id);
            });
        }

        public static News GetNewsById(TravelerPortalEntities db, int id)
        {
            return db.News.First(n => n.Id == id);
        }

        public static void UpdateNews(News news, string newBriefContent = null, string newDetailedContent = null)
        {
            var dbNews = default(News);
            DbUtils.OpenDbContext(db =>
            {
                dbNews = GetNewsById(db, news.Id);
                dbNews.Name = news.Name;
                dbNews.IsActive = news.IsActive;
                db.SaveChanges();
            });
            if (newBriefContent.HasValue())
                WriteContentOfNews(dbNews, ContentType.Brief, newBriefContent);
            if (newDetailedContent.HasValue())
                WriteContentOfNews(dbNews, ContentType.Detailed, newDetailedContent);
        }
    }
}