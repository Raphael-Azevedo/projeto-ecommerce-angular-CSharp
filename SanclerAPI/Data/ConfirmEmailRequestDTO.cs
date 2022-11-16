using System.ComponentModel.DataAnnotations;

namespace SanclerAPI.Data
{
    public class ConfirmEmailRequest
    {
        [Required]
        public string AcctivationCode { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}