using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[Route("api/admin")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Создание роли
    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
            return BadRequest("Role already exists");

        await _roleManager.CreateAsync(new IdentityRole(roleName));
        return Ok($"Role '{roleName}' created");
    }

    // Назначение роли пользователю
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(string email, string roleName)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return NotFound("User not found");

        if (!await _roleManager.RoleExistsAsync(roleName))
            return BadRequest("Role does not exist");

        await _userManager.AddToRoleAsync(user, roleName);
        return Ok($"Role '{roleName}' assigned to {email}");
    }

    // Удаление пользователя
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return NotFound("User not found");

        await _userManager.DeleteAsync(user);
        return Ok($"User {email} deleted");
    }

    [HttpPost("create-librarian")]
    public async Task<IActionResult> CreateLibrarian(string email, string password)
    {
        var librarian = new ApplicationUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(librarian, password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(librarian, "Librarian");
            return Ok("Librarian created successfully");
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("assign-librarian")]
    public async Task<IActionResult> AssignLibrarian(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return NotFound("User not found");

        await _userManager.AddToRoleAsync(user, "Librarian");
        return Ok($"{email} assigned as Librarian");
    }

    // Изменение роли пользователя
    [HttpPost("change-role")]
    public async Task<IActionResult> ChangeUserRole(string email, string oldRole, string newRole)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return NotFound("User not found");

        if (!await _roleManager.RoleExistsAsync(newRole))
            return BadRequest("New role does not exist");

        await _userManager.RemoveFromRoleAsync(user, oldRole);
        await _userManager.AddToRoleAsync(user, newRole);

        return Ok($"User {email} role changed from {oldRole} to {newRole}");
    }
}
