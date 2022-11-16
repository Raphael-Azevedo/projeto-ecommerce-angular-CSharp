using System.Collections.Generic;
using System.Threading.Tasks;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;

namespace SanclerAPI.Services.Interfaces
{
    public interface IInventoryServices
    {
        Task<IEnumerable<InventoryConteiner>> GetByProductId(int id);
        Task Create(CreateInventoryDTO inventoryDto);
        Task Update(int id, UpdateInventoryDTO inventoryDto);
        Task Delete(int id);
    }
}