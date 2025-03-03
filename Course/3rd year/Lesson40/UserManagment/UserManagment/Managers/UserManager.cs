namespace UserManagment.Managers;

using UserManagment.Models;
using UserManagment.Services;

public class UserManager : IUserReader, IUserWriter
{
    private readonly List<User> users = new();
    private readonly EmailService emailService;

    public UserManager(EmailService emailService)
    {
        this.emailService = emailService;
    }

    public void AddUser(User user)
    {
        users.Add(user);
        emailService.SendWelcomeEmail(user.Email);
    }

    public void DeleteUser(int userId)
    {
        var user = users.FirstOrDefault(u => u.Id == userId);
        if (user != null) users.Remove(user);
    }

    public User GetUser(int userId) => users.FirstOrDefault(u => u.Id == userId);
    public IEnumerable<User> GetAllUsers() => users;
}
