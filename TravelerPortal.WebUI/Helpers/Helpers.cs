using System;
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
                new MenuItem("Программы",urlHelper.RouteUrl("AllTravels")),
                new MenuItem("Расписание", urlHelper.RouteUrl("EventSchedule")),
                new MenuItem("Статьи", urlHelper.RouteUrl("AllArticles")),
                new MenuItem("Фотогалерея", urlHelper.RouteUrl("AllAlbums")),
                new MenuItem("Книги", urlHelper.RouteUrl("AllBooks")),
                new MenuItem("Новости", urlHelper.RouteUrl("AllNews")),
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

        private static string GetDeclension(int number, string nominative, string genitive_singular, string genitive_plural)
        {
            var formsTable = new[] { 2, 0, 1, 1, 1, 2, 2, 2, 2, 2 };
            number = Math.Abs(number);
            var res = formsTable[((((number % 100) / 10) != 1) ? 1 : 0) * (number % 10)];
            switch (res)
            {
                case 0:
                    return nominative;
                case 1:
                    return genitive_singular;
                default:
                    return genitive_plural;
            }
        }

        public static string GetDeclantionForDaysNumber(this HtmlHelper helper, int amountOfDays)
        {
            return GetDeclension(amountOfDays, "день", "дня", "дней");
        }
    }
}