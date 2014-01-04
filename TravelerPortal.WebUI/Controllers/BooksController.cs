using System.Linq;
using System.Web.Mvc;
using TravelerPortal.Services;
using TravelerPortal.WebUI.Views.Books;

namespace TravelerPortal.WebUI.Controllers
{
    public class BooksController : Controller
    {
        public BooksController()
        {
            ViewBag.ActiveMainMenuItemTitle = "Книги";
        }

        public ActionResult Books()
        {
            var dbBooks = BooksService.GetActive();
            var model = new BooksVM()
            {
                Books = dbBooks.Select(b => new BookVM()
                {
                    Author = b.Author,
                    Title = b.Title,
                    Description = b.Description,
                    ThumbnailPath = b.ThumbnailPath
                }).ToList()
            };
            return View(model);
        }
    }
}
