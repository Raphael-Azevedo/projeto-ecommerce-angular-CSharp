using SanclerAPI.DTO;

namespace SanclerAPI.HATEOAS.Conteiners
{
    public class AssessmentConteiner
    {
        public ReadAssessmentDTO asssesments { get; set; }
        public Link[] links { get; set; }  
    }
}