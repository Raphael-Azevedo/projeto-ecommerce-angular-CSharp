using SanclerAPI.DTO;

namespace SanclerAPI.HATEOAS.Conteiners
{
    public class CommentConteiner
    {
        public ReadCommentDTO comments { get; set; }
        public Link[] links { get; set; }  
    }
}