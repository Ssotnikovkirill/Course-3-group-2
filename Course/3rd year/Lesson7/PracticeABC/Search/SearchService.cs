using System.Linq;

public class SearchService
{
    public List<IBook> SearchBooks(IEnumerable<IBook> books, string searchTerm)
    {
        return books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<IUser> SearchUsers(IEnumerable<IUser> users, string searchTerm)
    {
        return users.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || u.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}