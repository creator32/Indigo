using System.Text;
using System.Web.Mvc;

namespace TravelerPortal.WebUI.Helpers
{
    public static class Helpers
    {
        /// <summary>
        /// Builds main menu
        /// </summary>
        public static MvcHtmlString BuildMainMenuItems(this HtmlHelper helper, UrlHelper urlHelper, string activeItemTitle)
        {
            var sb = new StringBuilder();
            var menuItems = new[]{
                new MenuItem("Главная", urlHelper.RouteUrl("Main")),
                new MenuItem("Фотогалерея",urlHelper.RouteUrl("AllAlbums")),
                new MenuItem("Статьи", urlHelper.RouteUrl("AllArticles")),
                new MenuItem("Новости", urlHelper.RouteUrl("AllNews")),
                new MenuItem("Программы", "javascript:notImplemented()"),
                new MenuItem("Книги", "javascript:notImplemented()"),
                new MenuItem("Отзывы", "javascript:notImplemented()"),
                new MenuItem("Цены", "javascript:notImplemented()"),
                new MenuItem("Контакты", "javascript:notImplemented()")
            };
            foreach (var menuItem in menuItems)
            {
                sb.AppendLine(
                    string.Format("<li {0}><a href='{1}'>{2}</a></li>",
                    (menuItem.Title == activeItemTitle) ? "class='active'" : string.Empty,
                    menuItem.Url,
                    menuItem.Title));
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}