using SanclerAPI.Models;
using SanclerAPI.Models.Enums;

namespace SanclerAPI.DTO
{
    public class ReadInventoryDTO
    {
        public int Id {get; set; }
        public Product product { get; set; }
        public Size Size { get; set; }
        public int Amount { get; set; }
    }
}