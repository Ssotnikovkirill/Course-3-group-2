using EmployeePortal.Data;  // для AppDbContext
using Microsoft.EntityFrameworkCore;  // для метода UseNpgsql
using Microsoft.AspNetCore.Builder;  // для UseRouting, UseCors и т.д.
using Microsoft.Extensions.DependencyInjection;  // для AddDbContext
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;  // для IHostEnvironment
using Microsoft.Extensions.Configuration;  // для IConfiguration
using Microsoft.AspNetCore.Http; // для куки аутентификации
using EmployeePortal.Models;  // для ApplicationUser

var builder = WebApplication.CreateBuilder(args);

// Добавляем конфигурацию для CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Добавляем контекст базы данных (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем Identity с ApplicationUser вместо IdentityUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Настройка аутентификации через куки
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Добавляем контроллеры для API
builder.Services.AddControllers();

// Добавляем Razor Pages
builder.Services.AddRazorPages(); // Добавление Razor Pages для представлений

var app = builder.Build();

// Настройка HTTP-конвейера
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Использование CORS политики
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // обязательно до UseAuthorization
app.UseAuthorization();

// Маршруты для Razor Pages
app.MapRazorPages(); // Настройка для Razor Pages

// Маршруты для MVC контроллеров
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Настройка маршрутов для контроллеров

// Инициализация ролей (Manager, Employee) и создание суперпользователя
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();  // Используем ApplicationUser
    
    string[] roles = { "Manager", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Создание пользователя с ролью Manager 
    var user = await userManager.FindByEmailAsync("admin@admin.com");
    if (user == null)
    {
        user = new ApplicationUser()  // Используем ApplicationUser
        {
            UserName = "admin@admin.com",
            Email = "admin@admin.com"
        };
        var createUserResult = await userManager.CreateAsync(user, "Admin@123");

        if (createUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Manager");
        }
    }
}

app.MapControllers();

app.Run();

