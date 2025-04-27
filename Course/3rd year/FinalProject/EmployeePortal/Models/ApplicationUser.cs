using Microsoft.AspNetCore.Identity;


namespace EmployeePortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; } = "Unknown";
    }
}
