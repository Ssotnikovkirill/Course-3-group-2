using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;

var builder = WebApplication.CreateBuilder(args);

//подключение SQLite
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();