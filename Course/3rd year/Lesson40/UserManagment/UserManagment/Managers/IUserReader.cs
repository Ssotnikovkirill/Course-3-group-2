namespace UserManagment.Managers;

using UserManagment.Models;

public interface IUserReader
{
    User GetUser(int userId);
    IEnumerable<User> GetAllUsers();
}
