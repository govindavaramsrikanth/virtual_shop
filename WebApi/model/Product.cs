namespace WebApi.models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsAvailable { get; set; }

        public required string Description { get; set; }
    }
}