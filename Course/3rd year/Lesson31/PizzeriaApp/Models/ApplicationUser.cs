using Microsoft.AspNetCore.Identity;
// для аутентификации
namespace PizzeriaApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
