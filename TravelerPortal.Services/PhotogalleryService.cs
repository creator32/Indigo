using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class PhotogalleryService
    {
        public static Album[] GetAllAlbums()
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Album.ToArray();
            });
        }
    }
}
