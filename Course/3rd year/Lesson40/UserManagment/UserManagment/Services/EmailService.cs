namespace UserManagment.Services;

public class EmailService
{
    public void SendWelcomeEmail(string email)
    {
        Console.WriteLine($"Sending welcome email to {email}");
    }
}
