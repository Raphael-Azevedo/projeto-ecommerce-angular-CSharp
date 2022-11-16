using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SanclerAPI.Context;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;

namespace SanclerAPI.Repository
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Inventory>> GetByProductId(int id)
        {
              return await Get()
                            .Where(c => c.Product.Id == id && c.Product.Status == true)
                            .Include(i => i.Product)
                            .ToListAsync();
        }
    }
}