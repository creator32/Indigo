using System.Configuration;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public class TravelsService : ContentPageBaseService<Travel>
    {
        public static new string pathToContentPages
        {
            get
            {
                return ConfigurationManager.AppSettings["pathToTravels"];
            }
        }
    }
}