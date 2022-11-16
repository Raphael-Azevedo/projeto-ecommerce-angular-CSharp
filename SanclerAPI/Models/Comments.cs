namespace SanclerAPI.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}