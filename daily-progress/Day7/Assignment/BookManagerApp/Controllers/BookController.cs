using System.Diagnostics;
using BookManagerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerApp.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> bookList = new List<Book>()
        {
            new Book() { Id = 1, Title = "Ponniyin Selvan", Author = "Kalki Krishnamurthy", Genre = "Historical Fiction" },
            new Book() { Id = 2, Title = "Silappathikaram", Author = "Ilango Adigal", Genre = "Epic Poetry" }
        };

        public IActionResult Index()
        {
            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            bookList.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var book = bookList.FirstOrDefault(b => b.Id == id);
            return PartialView("_BookDetails", book);
        }
    }

}
