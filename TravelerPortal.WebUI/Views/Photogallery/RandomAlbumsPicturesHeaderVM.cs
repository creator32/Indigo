using System.Collections.Generic;

namespace TravelerPortal.WebUI.Views.Photogallery
{
    public class RandomAlbumsPicturesHeaderVM
    {
        public RandomAlbumsPicturesHeaderVM()
        {
            Images = new List<RandomAlbumThumbnailVM>();
        }

        public List<RandomAlbumThumbnailVM> Images { get; set; }
    }
}