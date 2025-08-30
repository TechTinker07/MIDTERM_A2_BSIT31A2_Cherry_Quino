using Library_Management.Models;
using Library_Management_Domain.Entities;

public class BookdbService : IBookService
{
    public void AddBook(AddBookViewModel book)
    {
        throw new NotImplementedException();
    }

    public void AddCopy(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid id)
    {
        throw new NotImplementedException();
    }

    public EditBookViewModel GetBookById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookCopy> GetBookCopiesForBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public BookCopy? GetBookCopyById(Guid copyId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BookListViewModel> GetBooks()
    {
        throw new NotImplementedException();
    }

    public void UpdateBook(EditBookViewModel vm)
    {
        throw new NotImplementedException();
    }
}
