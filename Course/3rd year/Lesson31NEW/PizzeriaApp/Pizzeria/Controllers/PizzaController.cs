using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class PizzaController : Controller
{
    private readonly ApplicationDbContext _context;

    public PizzaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var pizzas = _context.Pizzas.ToList();
        return View(pizzas);
    }
}
