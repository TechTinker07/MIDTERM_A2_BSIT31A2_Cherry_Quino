using Library_Management.Models;
using Library_Management_Domain.Entities;

public interface IBookService
{
    void AddBook(AddBookViewModel book);
    void AddCopy(Guid bookId);
    void DeleteBook(Guid id);
    EditBookViewModel GetBookById(Guid id);
    IEnumerable<BookCopy> GetBookCopiesForBook(Guid bookId);
    BookCopy? GetBookCopyById(Guid copyId);
    IEnumerable<BookListViewModel> GetBooks();
    public void UpdateBook(Library_Management.Models.EditBookViewModel vm);
}