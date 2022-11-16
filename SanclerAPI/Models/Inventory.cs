using SanclerAPI.Models.Enums;

namespace SanclerAPI.Models

{
    public class Inventory
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
        public int Amount { get; set; }
    }
}