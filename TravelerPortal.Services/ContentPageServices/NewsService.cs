using System.Configuration;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public class NewsService : ContentPageBaseService<News>
    {
        public override string pathToContentPages
        {
            get
            {
                return ConfigurationManager.AppSettings["pathToNews"];
            }
        }
    }
}