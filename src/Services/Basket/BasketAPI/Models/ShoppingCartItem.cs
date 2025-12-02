namespace BasketAPI.Models
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = default!;
        public string Color { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public Guid ProduId { get; set; } = default!;
        public string ProductName { get; set; } = default!;
    }
}
