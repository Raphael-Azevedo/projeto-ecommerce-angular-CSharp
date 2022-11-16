using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.Data
{
    public class RequestReset
    {
        [Required]
        public string Email { get; set; }        
    }
}