using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=pizzeria.db"));

builder.Services.AddControllersWithViews(); // Включаем поддержку MVC

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}"); // Указываем маршрут по умолчанию

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Создаем таблицы, если они не существуют
    db.Database.EnsureCreated();

    // Добавляем тестовые данные
    if (!db.Pizzas.Any())
    {
        db.Pizzas.AddRange(
            new Pizza { Name = "Маргарита", Price = 8.99, Ingredients = "Томатный соус, сыр, базилик" },
            new Pizza { Name = "Пепперони", Price = 9.99, Ingredients = "Томатный соус, сыр, пепперони" },
            new Pizza { Name = "Гавайская", Price = 10.99, Ingredients = "Томатный соус, сыр, ананасы, ветчина" }
        );
        db.SaveChanges();
    }
}


app.Run();
