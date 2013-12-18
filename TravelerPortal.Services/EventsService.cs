using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class EventsService
    {
        public static Event[] GetActive()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Events.Where(e => e.IsActive).ToArray();
            });
        }
    }
}
