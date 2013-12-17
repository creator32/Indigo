﻿using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using TravelerPortal.Data;
using TravelerPortal.Shared;

namespace TravelerPortal.Services
{
    public static class ArticlesService
    {
        public static string pathToArticles;

        static ArticlesService()
        {
            pathToArticles = ConfigurationManager.AppSettings["pathToArticles"];
        }

        public static string ReadContentOfArticle(Article article, ContentType contentType)
        {
            var nameOfFile = (contentType == ContentType.Brief) ? article.BriefDescriptionPath : article.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToArticles, nameOfFile));
            return File.ReadAllText(pathToFile, Encoding.UTF8);
        }

        private static void WriteContentOfArticle(Article article, ContentType contentType, string newContent)
        {
            var nameOfFile = (contentType == ContentType.Brief) ? article.BriefDescriptionPath : article.DetailedDescriptionPath;
            var pathToFile = HttpContext.Current.Server.MapPath(string.Format(@"{0}/{1}", pathToArticles, nameOfFile));
            File.WriteAllText(pathToFile, newContent, Encoding.UTF8);
        }

        public static Article[] GetActiveArticles()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Articles.Where(a => a.IsActive).ToArray();
            });
        }

        public static Article[] GetAllArticles()
        {
            return DbUtils.OpenDbContext(db =>
            {
                return db.Articles.ToArray();
            });
        }

        public static Article GetArticleById(int id)
        {
            return DbUtils.OpenDbContext(db =>
            {
                return GetArticleById(db, id);
            });
        }

        public static Article GetArticleById(SoulTravelEntities db, int id)
        {
            return db.Articles.First(a => a.Id == id);
        }

        public static void UpdateArticle(Article article, string newBriefContent = null, string newDetailedContent = null)
        {
            var dbArticle = default(Article);
            DbUtils.OpenDbContext(db =>
            {
                dbArticle = GetArticleById(db, article.Id);
                dbArticle.Name = article.Name;
                dbArticle.IsActive = article.IsActive;
                db.SaveChanges();
            });
            if (newBriefContent.HasValue())
                WriteContentOfArticle(dbArticle, ContentType.Brief, newBriefContent);
            if (newDetailedContent.HasValue())
                WriteContentOfArticle(dbArticle, ContentType.Detailed, newDetailedContent);
        }
    }
}