using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookService.Instance.GetBooks();
            return View(books);
        }

        public IActionResult AddModal()
        {
            return PartialView("Add");
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm); // balik  Add view - may error
            }

            BookService.Instance.AddBook(vm);
            return RedirectToAction("Index"); //balik sa list para makita new book
        }

        public IActionResult EditModal(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null)
                return NotFound();

            // Get all copies for this book
            var copies = BookService.Instance.GetBookCopiesForBook(book.BookId).ToList();

            var vm = new EditBookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                Genre = book.Genre,
                PublishedDate = book.PublishedDate,
                CoverImageUrl = book.CoverImageUrl,
                Author = book.AuthorName,
                AuthorProfileImageUrl = book.AuthorProfileImageUrl,
                TotalCopies = copies.Count,
                AvailableCopies = copies.Count(c => c.PulloutDate == null),
                BookCopies = copies.Select(c => new BookCopyViewModel
                {
                    Id = c.Id,
                    Condition = c.Condition,
                    PulloutDate = c.PulloutDate,
                    PulloutReason = c.PulloutReason
                }).ToList()
            };

            return PartialView("_EditBookPartial", vm);
        }



        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BookService.Instance.UpdateBook(vm);
            return Ok();
        }

        public IActionResult DeleteModal(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null)
                return NotFound();

            return PartialView("_DeleteBookPartial", book);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null)
                return NotFound();

            BookService.Instance.DeleteBook(id);
            return Ok(); 
        }

        public IActionResult Details(Guid id)
        {
            var book = BookService.Instance.GetBookById(id);
            if (book == null) return NotFound();

            // Get all copies for this book
            var copies = BookService.Instance.GetBookCopiesForBook(book.BookId).ToList();

            var vm = new BookListViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                Description = book.Description,
                Genre = book.Genre,
                PublishedDate = book.PublishedDate,
                CoverImageUrl = copies.FirstOrDefault()?.CoverImageUrl,
                AuthorName = book.AuthorName,
                AuthorProfileImageUrl = book.AuthorProfileImageUrl,
                TotalCopies = copies.Count,
                AvailableCopies = copies.Count(c => c.PulloutDate == null),
                BookCopies = copies.Select(c => new BookCopyViewModel
                {
                    Id = c.Id,
                    Condition = c.Condition,
                    PulloutDate = c.PulloutDate,
                    PulloutReason = c.PulloutReason
                }).ToList()
            };

            return View(vm);
        }



        [HttpPost]
        public IActionResult AddCopy(Guid id)
        {
            BookService.Instance.AddCopy(id); // original logic to add a copy
            return RedirectToAction("Details", new { id }); // balik sa Details ng book
        }



        [HttpPost]
        public IActionResult PullOut(Guid copyId, string reason)
        {
            var copy = BookService.Instance.GetBookCopyById(copyId);
            if (copy == null) return NotFound();

            copy.PulloutDate = DateTime.Now;
            copy.PulloutReason = reason;

            // Redirect back to the same book details
            return RedirectToAction("Details", new { id = copy.Book.Id });
        }





    }
}
