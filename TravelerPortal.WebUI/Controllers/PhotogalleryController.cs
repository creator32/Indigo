using System;
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
            var albums = PhotogalleryService.GetActiveAlbums();
            var model = new AlbumsVM();
            model.Albums = albums.Select(a => new TravelerPortal.WebUI.Models.Photogallery.Album
            {
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
                .Select(ai => new TravelerPortal.WebUI.Models.Photogallery.AlbumImage
                {
                    Id = (int)ai.Id,
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

        [ChildActionOnly]
        public PartialViewResult RandomAlbumsPicturesHeader()
        {
            var dbActiveAlbums = PhotogalleryService.GetActiveAlbums("AlbumImages");
            var model = new RandomAlbumsPicturesHeaderVM()
            {
                Images = (from dbAlbum in dbActiveAlbums
                          let randomAlbumImage = dbAlbum.AlbumImages.ToArray()[new Random().Next(1, dbAlbum.AlbumImages.Count())]
                          select new RandomAlbumThumbnailVM()
                          {
                              AlbumId = (int)dbAlbum.Id,
                              AlbumImageId = (int)randomAlbumImage.Id,
                              Thumbnail = randomAlbumImage.Thumbnail
                          })
                          .ToList()
            };
            return PartialView(model);
        }
    }
}