using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    Description = b.Description,
                    ThumbnailPath = b.ThumbnailPath
                }).ToList()
            };
            return View(model);
        }

        public async Task Download(int bookId)
        {
            using (var httpClient = new HttpClient())
            {
                var dbBook = BooksService.GetById(bookId);
                var uri = dbBook.Uri;
                var fileAsByteArray = await httpClient.GetByteArrayAsync(uri);
                var fileName = Path.GetFileName(uri);
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
                Response.Flush();
                Response.BinaryWrite(fileAsByteArray);
                Response.End();
            }
        }

        public RedirectResult Read(int bookId)
        {
            var dbBook = BooksService.GetById(bookId);
            var uri = dbBook.Uri;
            return RedirectPermanent(uri);
        }
    }
}
