using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.DTO
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(100, ErrorMessage = "This attribute can only 100 carachteres")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(300, ErrorMessage = "This attribute can only 300 carachteres")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(15, ErrorMessage = "This attribute can only 15 carachteres")]
        public string SKU { get; set; }
    
        [Required(ErrorMessage = "This attribute is required!")]
        public decimal Price { get; set; }
    }
}