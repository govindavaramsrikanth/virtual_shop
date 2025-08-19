namespace WebApi.models
{ 
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }   
}