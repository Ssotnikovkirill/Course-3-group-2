using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBookManager
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<Book> GetBookById(int id);
    Task AddBook(Book book);
    Task DeleteBook(int id);
}
