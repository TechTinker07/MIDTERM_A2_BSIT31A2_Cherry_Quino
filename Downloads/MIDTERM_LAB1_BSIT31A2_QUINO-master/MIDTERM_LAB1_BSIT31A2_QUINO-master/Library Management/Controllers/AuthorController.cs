
using Microsoft.AspNetCore.Mvc;
using Library_Management.Models;
using Library_Management.Services;
namespace Library_Management.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            var authors = AuthorService.Instance.GetAuthors();
            return View(authors);
        }
        public IActionResult Details(Guid Id)
        {
            var author = AuthorService.Instance.GetAuthorById(Id);
            if (author == null) return NotFound();
            return View(author);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (!ModelState.IsValid) return View(author);
            AuthorService.Instance.AddAuthor(author);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid id)
        {
            var author = AuthorService.Instance.GetAuthorById(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid) return View(author);
            AuthorService.Instance.UpdateAuthor(author);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var author = AuthorService.Instance.GetAuthorById(id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            AuthorService.Instance.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        public IActionResult Archive(Guid id)
        {
            AuthorService.Instance.ArchiveAuthor(id);
            return RedirectToAction("Index");
        }

        public IActionResult Restore(Guid id)
        {
            AuthorService.Instance.RestoreAuthor(id);
            return RedirectToAction("Index");
        }
    }
}