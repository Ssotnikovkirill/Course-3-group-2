using Microsoft.AspNetCore.Mvc;
using PizzeriaApp.Data;
using PizzeriaApp.Models;
using System.Linq;

namespace PizzeriaApp.Controllers
{
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

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }
    }
}
