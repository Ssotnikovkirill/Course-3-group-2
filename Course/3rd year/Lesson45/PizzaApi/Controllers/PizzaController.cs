using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PizzaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        /// <summary>
        /// Получить список всех пицц
        /// </summary>
        /// <returns>Список пицц</returns>
        [HttpGet]
        public ActionResult<List<string>> GetPizzas()
        {
            return new List<string> { "Маргарита", "Пепперони", "Четыре сыра" };
        }
    }
}
