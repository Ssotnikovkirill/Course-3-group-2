namespace UserManagment.Managers;

using UserManagment.Models;

public class DbUserManager : IUserManager
{
    private readonly List<User> dbUsers = new();

    public void AddUser(User user)
    {
        dbUsers.Add(user);
        Console.WriteLine($"User {user.Username} added to database.");
    }

    public void DeleteUser(int userId)
    {
        var user = dbUsers.FirstOrDefault(u => u.Id == userId);
        if (user != null) dbUsers.Remove(user);
    }

    public User GetUser(int userId) => dbUsers.FirstOrDefault(u => u.Id == userId);
    public IEnumerable<User> GetAllUsers() => dbUsers;
}

//можно заменить, и если UserController будет работать без изменений — значит, принцип Барбары Лисков соблюден