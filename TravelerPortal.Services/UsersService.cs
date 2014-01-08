using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class UsersService
    {
        public static User GetByFBIdOrByVKId(string fbId, string vkId)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return GetByFBIdOrByVKId(db, fbId, vkId);
            });
        }

        public static User GetByFBIdOrByVKId(SoulTravelEntities db, string fbId, string vkId)
        {
            return db.Users.FirstOrDefault(u => u.FBId == fbId || u.VKId == vkId);
        }
    }
}
