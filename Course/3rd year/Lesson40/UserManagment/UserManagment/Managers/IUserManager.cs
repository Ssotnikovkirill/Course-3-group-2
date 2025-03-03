namespace UserManagment.Managers;

using UserManagment.Models;

public interface IUserManager
{
    void AddUser(User user);
    void DeleteUser(int userId);
    User GetUser(int userId);
    IEnumerable<User> GetAllUsers();
}
