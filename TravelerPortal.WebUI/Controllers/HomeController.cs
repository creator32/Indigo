using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var albums = PhotogalleryService.GetAllAlbums();
            return View(albums);
        }
    }
}
