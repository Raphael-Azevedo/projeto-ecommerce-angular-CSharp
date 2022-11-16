using System.Collections.Generic;
using System.Threading.Tasks;
using SanclerAPI.Models;

namespace SanclerAPI.Repository.Interfaces
{
    public interface IInventoryRepository :IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetByProductId(int id);
    }
}