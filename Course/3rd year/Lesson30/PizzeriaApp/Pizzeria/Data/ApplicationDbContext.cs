using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
}
