// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using EmployeePortal.Models;

// namespace EmployeePortal.Data
// {
//     public class AppDbContext : IdentityDbContext
//     {
//         public AppDbContext(DbContextOptions<AppDbContext> options)
//             : base(options)
//         {
//         }

//         public DbSet<User> Users { get; set; }
//         public DbSet<Meet> Meets { get; set; }
//     }
// }

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeePortal.Models;

namespace EmployeePortal.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>  // Меняем на ApplicationUser
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Убираем DbSet<User>, так как теперь будем использовать ApplicationUser
        public DbSet<Meet> Meets { get; set; }

        // Если нужно добавить другие сущности, например, если есть таблицы для сотрудников
        //public DbSet<Employee> Employees { get; set; }
    }
}
