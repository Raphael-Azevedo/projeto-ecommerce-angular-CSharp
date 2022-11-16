using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.DTO
{
    public class CreateInventoryDTO
    {
        [Required(ErrorMessage = "This attribute is required!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [Range(1, 6, ErrorMessage = "This attibute must be between 1 and 6!")]
        public int Size { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        public int Amount { get; set; }
    }
}