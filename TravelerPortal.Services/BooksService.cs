using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class BooksService
    {
        public static Book[] GetActive()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Books.Where(b => b.IsActive).ToArray();
            });
        }
    }
}
