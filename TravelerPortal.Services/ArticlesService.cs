using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class ArticlesService
    {
        public static Article[] GetAllArticles()
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Articles.ToArray();
            });
        }

        public static Article GetArticleById(int id)
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Articles.First(a => a.Id == id);
            });
        }
    }
}