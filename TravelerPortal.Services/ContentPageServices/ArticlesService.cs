using System.Configuration;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public class ArticlesService : ContentPageBaseService<Article>
    {
        public static new string pathToContentPages
        {
            get
            {
                return ConfigurationManager.AppSettings["pathToArticles"];
            }
        }
    }
}