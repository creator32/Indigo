using System.Collections.Generic;

namespace TravelerPortal.WebUI.Models
{
    public class Album
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CoverPath { get; set; }

        public List<AlbumImage> AlbumImages { get; set; }
    }
}