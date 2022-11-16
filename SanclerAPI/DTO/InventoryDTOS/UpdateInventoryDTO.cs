using SanclerAPI.Models.Enums;

namespace SanclerAPI.DTO
{
    public class UpdateInventoryDTO
    {
        public Size Size { get; set; }
        public int Amount { get; set; }
    }
}