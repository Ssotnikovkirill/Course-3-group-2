namespace PracticeABC;

class Program
{
    static void Main()
    {
        var bookService = new BookService();
        var userService = new UserService();
        var searchService = new SearchService();

        //добавление книг
        bookService.AddBook(new ConcreteBook(1, "Война и мир", "Лев Толстой"));
        bookService.AddBook(new ConcreteBook(2, "Кто нашел берет себе", "Стивен Кинг"));

        //добавление пользователей
        userService.AddUser(new ConcreteUser(1, "Кирилл Сотников", "kirillgor1217@gmail.com"));
        userService.AddUser(new ConcreteUser(2, "Кто-то", "noname@gmail.com"));

        // поиск книг
        var foundBooks = searchService.SearchBooks(bookService.GetAllBooks(), "Война");
        Console.WriteLine("найденные книги:");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"{book.Title} - {book.Author}");
        }

        // поиск пользователей
        var foundUsers = searchService.SearchUsers(userService.GetAllUsers(), "Кирилл");
        Console.WriteLine("найденные пользователи:");
        foreach (var user in foundUsers)
        {
            Console.WriteLine($"{user.Name} - {user.Email}");
        }
    }
}
