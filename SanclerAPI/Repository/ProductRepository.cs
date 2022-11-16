using System.Threading.Tasks;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Models;
using SanclerAPI.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SanclerAPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task BoleanDelete(int id)
        {
            var product = await GetById(c => c.Id == id);

            product.Status = false;
        }
        public IQueryable<Product> GetAll(int skip = 0, int take = 10)
        {
            skip = skip * take;
            return _context.Set<Product>()
                     .Where(p => p.Status == true)
                     .Skip(skip)
                     .Take(take)
                     .AsNoTracking();
        }
    }
}