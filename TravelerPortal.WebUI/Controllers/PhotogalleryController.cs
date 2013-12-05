using System.Linq;
using System.Web.Mvc;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Views.Photogallery;

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
            var model = new AlbumsVM();
            model.Albums = albums.Select(a => new TravelerPortal.WebUI.Models.Album { 
                Id = a.Id,
                Name = a.Name,
                CoverPath = a.CoverPath
            }).ToList();
            return View(model);
        }

        public ActionResult Album(int albumId)
        {
            var album = PhotogalleryService.GetAlbumWithImages(albumId);
            var albumImages = album.AlbumImages
                .Select(ai => new TravelerPortal.WebUI.Models.AlbumImage {
                    Name = ai.Name,
                    Description = ai.Description,
                    ThumbPath = ai.Path,
                    ThumbnailPath = ai.Thumbnail
                }).ToList();
            var model = new AlbumVM
            {
                Name = album.Name,
                Images = albumImages
            };
            return View(model);
        }
    }
}