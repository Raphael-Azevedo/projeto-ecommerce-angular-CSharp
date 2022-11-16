using SanclerAPI.Models;

namespace SanclerAPI.HATEOAS.Conteiners
{
    public class ProductConteiner
    {
        public Product product { get; set; }
        public Link[] links { get; set; }  
    }
}