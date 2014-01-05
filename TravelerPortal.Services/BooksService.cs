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

        public static Book GetById(int id)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Books.First(b => b.Id == id);
            });
        }
    }
}
