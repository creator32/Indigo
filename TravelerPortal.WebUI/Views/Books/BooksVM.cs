using System.Collections.Generic;

namespace TravelerPortal.WebUI.Views.Books
{
    public class BooksVM
    {
        public List<BookVM> Books { get; set; }

        public BooksVM()
        {
            Books = new List<BookVM>();
        }
    }
}