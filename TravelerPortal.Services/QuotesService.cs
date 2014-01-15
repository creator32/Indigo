using System;
using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class QuotesService
    {
        public static Quote GetRandom()
        {
            return DbUtils.OpenDbContext(db =>
            {
                var quotesAmount = db.Quotes.Count();
                var quotesToSkip = new Random().Next(0, quotesAmount);
                return db.Quotes.OrderBy(q => q.Id).Skip(quotesToSkip).Take(1).First();
            });
        }
    }
}
