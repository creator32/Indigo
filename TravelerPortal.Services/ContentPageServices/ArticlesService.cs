using System.Configuration;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public class ArticlesService : ContentPageBaseService<Article>
    {
        public override string pathToContentPages
        {
            get
            {
                return ConfigurationManager.AppSettings["pathToArticles"];
            }
        }
    }
}