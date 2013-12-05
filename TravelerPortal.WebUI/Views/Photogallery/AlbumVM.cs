using System.Collections.Generic;
using TravelerPortal.WebUI.Models;

namespace TravelerPortal.WebUI.Views.Photogallery
{
    public class AlbumVM
    {
        public AlbumVM()
        {
            Images = new List<AlbumImage>();
        }

        public string Name { get; set; }
        public List<AlbumImage> Images { get; set; }
    }
}