using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Data;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaContext _context;

        public PizzaController(PizzaContext context)
        {
            _context = context;
        }

        // Получить все пиццы с пагинацией, сортировкой и фильтрацией
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas(
            int page = 1, int pageSize = 5, string? sortBy = "name", string? filter = null)
        {
            var query = _context.Pizzas.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
                query = query.Where(p => p.Name.Contains(filter));

            query = sortBy switch
            {
                "price" => query.OrderBy(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                _ => query.OrderBy(p => p.Name)
            };

            var totalItems = await query.CountAsync();
            var pizzas = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(new { totalItems, pizzas });
        }

        // Получить пиццу по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
                return NotFound();
            return pizza;
        }

        // Создать новую пиццу
        [HttpPost]
        public async Task<ActionResult<Pizza>> CreatePizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        // Обновить пиццу
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pizzas.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // Удалить пиццу
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
                return NotFound();

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
