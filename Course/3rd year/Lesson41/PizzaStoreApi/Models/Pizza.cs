using System.ComponentModel.DataAnnotations;

namespace PizzaStoreApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Ingredients { get; set; } = string.Empty;

        [Range(0.01, 100.00)]
        public decimal Price { get; set; }
    }
}
