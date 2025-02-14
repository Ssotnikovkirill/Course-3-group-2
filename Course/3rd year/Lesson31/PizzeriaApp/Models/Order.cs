using System.Collections.Generic;
// заказ
namespace PizzeriaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
    }
}
