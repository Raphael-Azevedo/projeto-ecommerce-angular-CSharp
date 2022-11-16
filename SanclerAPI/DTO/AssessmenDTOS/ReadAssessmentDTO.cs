using System.ComponentModel.DataAnnotations;
using SanclerAPI.Models;

namespace SanclerAPI.DTO
{
    public class ReadAssessmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        public Product Product { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(150, ErrorMessage = "This attribute can only 150 carachteres")]
        public int Evaluation { get; set; }
    }
}