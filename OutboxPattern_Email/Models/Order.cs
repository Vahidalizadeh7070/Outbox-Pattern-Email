namespace OutboxPattern_Email.Models
{
    public class Order
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public string Email { get; set; }
    }
}
