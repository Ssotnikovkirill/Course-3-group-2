using System.Collections.Generic;
using System.Linq;

public class BookService
{
    private List<IBook> books = new List<IBook>();

    public void AddBook(IBook book)
    {
        books.Add(book);
    }

    public void EditBook(int id, string title, string author)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            book.Title = title;
            book.Author = author;
        }
    }

    public void RemoveBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            books.Remove(book);
        }
    }

    public List<IBook> GetAllBooks() => books;
}