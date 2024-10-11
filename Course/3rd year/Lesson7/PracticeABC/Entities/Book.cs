public abstract class Book : IBook
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }

    protected Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }
}

public class ConcreteBook : Book
{
    public ConcreteBook(int id, string title, string author) : base(id, title, author) { }
}