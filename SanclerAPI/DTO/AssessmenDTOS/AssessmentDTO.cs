using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.DTO
{
    public class CreateAssessmentDTO
    {
        [Display(Name = "Product Id")]
        [Required(ErrorMessage = "This attribute is required!")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [Range(1, 5, ErrorMessage = "This attibute must be between 1 and 5!")]
        public int Evaluation { get; set; }
    }
}