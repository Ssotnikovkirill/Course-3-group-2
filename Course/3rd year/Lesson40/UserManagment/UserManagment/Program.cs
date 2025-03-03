using UserManagment.Managers;
using UserManagment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Регистрация сервисов
builder.Services.AddSingleton<EmailService>();
builder.Services.AddSingleton<IUserReader, UserManager>();
builder.Services.AddSingleton<IUserWriter, UserManager>();

// builder.Services.AddSingleton<IUserManager, DbUserManager>(); //можно заменить, и если UserController будет работать без изменений — значит, принцип Барбары Лисков соблюден


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
