public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
}
