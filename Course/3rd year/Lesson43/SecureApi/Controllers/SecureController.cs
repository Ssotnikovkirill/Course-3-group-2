using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers;

[ApiController]
[Route("api/secure")]
public class SecureController : ControllerBase
{
    [Authorize]
    [HttpGet("user")]
    public IActionResult GetUserInfo()
    {
        return Ok(new { Message = "Доступно для всех аутентифицированных пользователей" });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult GetAdminInfo()
    {
        return Ok(new { Message = "Доступно только для Админа" });
    }
}
