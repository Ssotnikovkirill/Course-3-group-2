using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
