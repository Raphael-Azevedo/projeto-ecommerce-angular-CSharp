using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SanclerAPI.DTO
{
    public class UpdateProductDTO
    {
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(100, ErrorMessage = "This attribute can only 100 carachteres")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This attribute is required!")]
        [MaxLength(300, ErrorMessage = "This attribute can only 300 carachteres")]
        public string Descriptions { get; set; }    
        [Required(ErrorMessage = "This attribute is required!")]
        public decimal Price { get; set; }
    }
}