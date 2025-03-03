namespace UserManagment.Controllers;

using Microsoft.AspNetCore.Mvc;
using UserManagment.Managers;
using UserManagment.Models;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserReader userReader;
    private readonly IUserWriter userWriter;

    public UserController(IUserReader userReader, IUserWriter userWriter)
    {
        this.userReader = userReader;
        this.userWriter = userWriter;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(string username, string email)
    {
        var user = new User { Username = username, Email = email };
        userWriter.AddUser(user);
        return Ok(new { message = $"User {username} created." });
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(int userId)
    {
        userWriter.DeleteUser(userId);
        return Ok(new { message = $"User with ID {userId} removed." });
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(int userId)
    {
        var user = userReader.GetUser(userId);
        return user != null ? Ok(user) : NotFound(new { message = "User not found." });
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        return Ok(userReader.GetAllUsers());
    }
}
