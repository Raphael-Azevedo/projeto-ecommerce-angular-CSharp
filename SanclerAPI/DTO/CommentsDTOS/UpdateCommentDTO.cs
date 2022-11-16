using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.DTO
{
    public class UpdateCommentDTO
    {
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(150, ErrorMessage = "This attribute can only 150 carachteres")]
        public string Comment { get; set; }
    }
}