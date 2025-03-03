namespace UserManagment.Managers;

using UserManagment.Models;

public interface IUserWriter
{
    void AddUser(User user);
    void DeleteUser(int userId);
}
