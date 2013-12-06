using System.Data.Entity;
using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class PhotogalleryService
    {
        public static Album[] GetActiveAlbums()
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Albums.Where(a => a.IsActive).ToArray();
            });
        }

        public static Album[] GetAllAlbums()
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Albums.ToArray();
            });
        }

        public static Album GetAlbumWithImages(int albumId)
        {
            return DbUtils.DoDbOperation((db) =>
            {
                return db.Albums.Include(a => a.AlbumImages).First((a) => a.Id == albumId);
            });
        }
    }
}
