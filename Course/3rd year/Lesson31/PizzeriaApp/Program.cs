using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzeriaApp.Data;
using PizzeriaApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;




// var builder = WebApplication.CreateBuilder(args);

// Подключаем SQLite
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite("Data Source=pizzeria.db"));
var builder = WebApplication.CreateBuilder(args);

// Строка подключения к базе данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Добавление DbContext для работы с базой данных и Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Настройка Identity с использованием EntityFramework
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Настройка Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();










