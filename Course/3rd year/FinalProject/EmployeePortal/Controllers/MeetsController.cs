using Microsoft.AspNetCore.Mvc;
using EmployeePortal.Models;
using EmployeePortal.Models.Dto;
using EmployeePortal.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/meets
        [HttpPost]
        public async Task<IActionResult> CreateMeet([FromBody] MeetDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound($"Пользователь с id {dto.UserId} не найден");
            }

            var meet = new Meet
            {
                Title = dto.Title,
                Date = dto.Date,
                UserId = dto.UserId
            };

            _context.Meets.Add(meet);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Встреча добавлена успешно" });
        }

        // GET: api/meets
        [HttpGet]
        public async Task<IActionResult> GetMeets()
        {
            var meets = await _context.Meets
                .Include(m => m.User)
                .ToListAsync();

            return Ok(meets);
        }

        // GET: api/meets/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetById(int id)
        {
            var meet = await _context.Meets
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meet == null)
            {
                return NotFound();
            }

            return Ok(meet);
        }
    }
}
