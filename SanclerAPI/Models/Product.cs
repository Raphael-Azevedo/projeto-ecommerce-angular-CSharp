namespace SanclerAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string SKU { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
    }
}