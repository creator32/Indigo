using Google.GData.Photos;
using TravelerPortal.Data;

namespace GoogleImagesCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            DbUtils.OpenDbContext(db =>
            {
                // clear Db 
                db.Database.ExecuteSqlCommand("DELETE FROM [Album]");
                // 
                PicasaService service = new PicasaService("");
                var feed = default(PicasaFeed);
                // add albums
                {

                    AlbumQuery albumQuery = new AlbumQuery(PicasaQuery.CreatePicasaUri("109913968155621160630"));
                    feed = service.Query(albumQuery);
                    foreach (PicasaEntry entry in feed.Entries)
                    {
                        var apiAlbum = new AlbumAccessor(entry);
                        db.Albums.Add(new Album
                        {
                            ExternalId = apiAlbum.Id,
                            Name = apiAlbum.AlbumTitle,
                            CoverPath = entry.Media.Thumbnails[0].Url,
                            IsActive = false
                        });
                    }
                    db.SaveChanges();
                }
                // add images to albums
                {
                    foreach (var dbAlbum in db.Albums)
                    {
                        PhotoQuery photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri("109913968155621160630", dbAlbum.ExternalId));
                        feed = service.Query(photoQuery);
                        foreach (PicasaEntry entry in feed.Entries)
                        {
                            dbAlbum.AlbumImages.Add(new AlbumImage
                            {
                                Name = entry.Title.Text,
                                Path = entry.Media.Contents[0].Url,
                                Thumbnail = entry.Media.Thumbnails[entry.Media.Thumbnails.Count - 1].Url,
                                Description = entry.Media.Description.Value
                            });
                        }
                    }
                    db.SaveChanges();
                }
            });
        }
    }
}
