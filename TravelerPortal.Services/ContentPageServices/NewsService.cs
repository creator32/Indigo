using System.Configuration;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public class NewsService : ContentPageBaseService<News>
    {
        public static new string pathToContentPages
        {
            get
            {
                return ConfigurationManager.AppSettings["pathToNews"];
            }
        }
    }
}