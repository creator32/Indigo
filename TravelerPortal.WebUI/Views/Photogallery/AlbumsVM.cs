using System.Collections.Generic;
using TravelerPortal.WebUI.Models.Photogallery;

namespace TravelerPortal.WebUI.Views.Photogallery
{
    public class AlbumsVM
    {
        public AlbumsVM()
        {
            Albums = new List<Album>();
        }

        public List<Album> Albums { get; set; }
    }
}