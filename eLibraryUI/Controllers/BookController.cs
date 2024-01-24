using Dapper;
using eLibraryData.BusinessLogic;
using eLibraryData.Models;
using eLibraryUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eLibraryUI.Controllers
{
    public class BookController : Controller
    { 
      
        //Get: Book/Index
        public IActionResult Index()
        {
            var data = BooksBizLogic.GetAllBooks();
            List<Books> books = new List<Books>();


            data.ForEach(book => books.Add(new Books
            {
                BookID = book.BookID,
                Title = book.Title,
                ISBN =  book.ISBN,
                GenreID = book.GenreID,
                PublishedDate = book.PublishedDate,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
                TotalPages = book.TotalPages,
                PublisherID = book.PublisherID,
                AuthorID = book.AuthorID
            }));

            return View(books);
        }

        //Get: Book/AddOrEdit
        public IActionResult AddOrEdit(int Id)
        {

            if(Id == 0)
            {
                PopulateLists();
                return View(new Books());
            }
            else
            {
                PopulateLists();
                var data = BooksBizLogic.GetBookByID(Id);
                Books book = new Books
                {
                    BookID = data.BookID,
                    Title = data.Title,
                    ISBN = data.ISBN,
                    GenreID = data.GenreID,
                    PublishedDate = data.PublishedDate,
                    TotalCopies = data.TotalCopies,
                    AvailableCopies = data.AvailableCopies,
                    TotalPages = data.TotalPages,
                    PublisherID = data.PublisherID,
                    AuthorID = data.AuthorID
                };

                return View(book);
            }
        }

        //Post: Book/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Books book)
        {
            try
            {
                BooksBizLogic.AddOrEdit(new BookModel
                {
                    BookID = book.BookID,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    GenreID = book.GenreID,
                    PublishedDate = book.PublishedDate,
                    TotalCopies = book.TotalCopies,
                    AvailableCopies = book.AvailableCopies,
                    TotalPages = book.TotalPages,
                    PublisherID = book.PublisherID,
                    AuthorID = book.AuthorID
                });
                return RedirectToAction("Index");
            }
             catch
            {
                return View();
            }
        }

        //Post: Book/Delete/?Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            try
            {
                BooksBizLogic.DeleteBook(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public void PopulateLists()
        {
            var genreList = GenreBizLogic.GetAllGenre();
            ViewBag.GenreList = new SelectList(genreList, "GenreID", "GenreName");

            var publisherList = PublishersBizLogic.GetAllPublishers();
            ViewBag.PublisherList = new SelectList(publisherList, "PublisherID", "PublisherName");

            var authorList = AuthorsBizLogic.GetAllAuthors();
            ViewBag.AuthorList = new SelectList(authorList, "AuthorID", "FirstName");
        }
    }
}
