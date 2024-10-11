using System.Collections.Generic;
using System.Linq;

public class UserService
{
    private List<IUser> users = new List<IUser>();

    public void AddUser(IUser user)
    {
        users.Add(user);
    }

    public void EditUser(int id, string name, string email)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.Name = name;
            user.Email = email;
        }
    }

    public void RemoveUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            users.Remove(user);
        }
    }

    public List<IUser> GetAllUsers() => users;
}