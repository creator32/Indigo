using System;
using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class OpinionsService
    {
        public static Opinion GetRandom()
        {
            return DbUtils.OpenDbContext(db =>
            {
                var opinionsAmount = db.Opinions.Where(o => o.IsActive).Count();
                var opinionsToSkip = new Random().Next(0, opinionsAmount);
                return db.Opinions.Where(o => o.IsActive).OrderBy(o => o.Id).Skip(opinionsToSkip).Take(1).First();
            });
        }
    }
}
