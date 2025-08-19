namespace WebApi.models
{
    public class Order
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
    }
}       
