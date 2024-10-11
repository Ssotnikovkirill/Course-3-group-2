public abstract class User : IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    protected User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}

public class ConcreteUser : User
{
    public ConcreteUser(int id, string name, string email) : base(id, name, email) { }
}