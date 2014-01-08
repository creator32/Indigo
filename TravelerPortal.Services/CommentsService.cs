using System;
using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class CommentsService
    {
        public static Comment[] GetActive(int areaId, int entityId, string fieldsToInclude)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Comments.Include(fieldsToInclude).Where(c => c.AreaId == areaId && c.EntityId == entityId && c.IsActive).ToArray();
            });
        }

        public static void Add(Comment comment, User user)
        {
            comment.Id = 0;
            comment.Created = DateTime.UtcNow;
            DbUtils.OpenDbContext(db =>
            {
                // search for a user with the same FBId or VKId
                var dbUser = UsersService.GetByFBIdOrByVKId(db, user.FBId, user.VKId);
                if (dbUser != null)
                {
                    // attach new comment to an existing user
                    comment.UserId = dbUser.Id;
                    db.Comments.Add(comment);
                }
                else
                {
                    // attach new user to new comment
                    user.Id = 0;
                    user.Created = DateTime.UtcNow;
                    comment.User = user;
                    db.Comments.Add(comment);
                }
                db.SaveChanges();
            });
        }
    }
}
