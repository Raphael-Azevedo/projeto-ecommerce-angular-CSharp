using SanclerAPI.Models.Enums;

namespace SanclerAPI.Models
{
    public class Assessments
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Product Product { get; set; }
        public Evaluations Evaluation { get; set; }

    }
}