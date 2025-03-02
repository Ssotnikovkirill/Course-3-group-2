using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookManager _bookManager;

    public BooksController(IBookManager bookManager)
    {
        _bookManager = bookManager;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _bookManager.GetAllBooks();
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Librarian")]
    public async Task<IActionResult> CreateBook(Book book)
    {
        await _bookManager.AddBook(book);
        return Ok("Book added successfully");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Librarian")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookManager.DeleteBook(id);
        return Ok("Book deleted successfully");
    }
}
