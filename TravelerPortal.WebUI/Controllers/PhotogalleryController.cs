using System.Web.Mvc;
using TravelerPortal.Services;

namespace TravelerPortal.WebUI.Controllers
{
    public class PhotogalleryController : Controller
    {
        public PhotogalleryController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Фотогалерея";
        }

        public ActionResult Albums()
        {
            var albums = PhotogalleryService.GetAllAlbums();
            return View(albums);
        }

        public ActionResult Album(int albumId)
        {
            var album = PhotogalleryService.GetAlbumWithImages(albumId);
            return View(album);
        }
    }
}