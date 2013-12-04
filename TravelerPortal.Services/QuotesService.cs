using System;
using System.Linq;
using TravelerPortal.Data;

namespace TravelerPortal.Services
{
    public static class QuotesService
    {
        public static Quote GetRandomQuote()
        {
            return DbUtils.DoDbOperation(db =>
            {
                var quotesAmount = db.Quotes.Count();
                var quotesToSkip = new Random().Next(0, quotesAmount - 1);
                return db.Quotes.OrderBy(q => q.Id).Skip(quotesToSkip).Take(1).First();
            });
        }
    }
}
