using SanclerAPI.DTO;

namespace SanclerAPI.HATEOAS.Conteiners
{
    public class InventoryConteiner
    {
        public ReadInventoryDTO inventory { get; set; }
        public Link[] links { get; set; }  
    }
}