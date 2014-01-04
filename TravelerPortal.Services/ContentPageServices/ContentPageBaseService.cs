using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TravelerPortal.Data;
using TravelerPortal.Shared;

namespace TravelerPortal.Services
{
    public abstract class ContentPageBaseService<T>
        where T : class, IHasContentPages, new()
    {
        public abstract string pathToContentPages { get; }

        public string ReadContent(T entity, ContentType contentType)
        {
            var nameOfFile = (contentType == ContentType.Brief) ? entity.BriefDescriptionPath : entity.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToContentPages, nameOfFile));
            return File.ReadAllText(pathToFile, Encoding.UTF8);
        }

        private void WriteContent(T entity, ContentType contentType, string newContent)
        {
            var nameOfFile = (contentType == ContentType.Brief) ? entity.BriefDescriptionPath : entity.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToContentPages, nameOfFile));
            File.WriteAllText(pathToFile, newContent, Encoding.UTF8);
        }

        public T[] GetActive()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Set<T>().Where(a => a.IsActive).ToArray();
            });
        }

        public T[] GetAll()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Set<T>().ToArray();
            });
        }

        public T GetById(int id)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return GetById(db, id);
            });
        }

        public T GetById(SoulTravelEntities db, int id)
        {
            return db.Set<T>().First(a => a.Id == id);
        }

        public void Update(T entity, string newBriefContent = null, string newDetailedContent = null)
        {
            var dbentity = default(T);
            DbUtils.OpenDbContext(db =>
            {
                dbentity = GetById(db, entity.Id);
                dbentity.Name = entity.Name;
                dbentity.IsActive = entity.IsActive;
                db.SaveChanges();
            });
            if (newBriefContent.HasValue())
                WriteContent(dbentity, ContentType.Brief, newBriefContent);
            if (newDetailedContent.HasValue())
                WriteContent(dbentity, ContentType.Detailed, newDetailedContent);
        }
    }
}
