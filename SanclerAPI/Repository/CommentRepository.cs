using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SanclerAPI.Context;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;

namespace SanclerAPI.Repository
{
    public class CommentRepository : Repository<Comments>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Comments> GetByIdWithProduct(int id)
        {
            return await _context.Comments.Include(c => c.Product).FirstAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comments>> GetByProductId(int Id, int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Comments>()
                            .Where(c => c.Product.Id == Id  && c.Product.Status == true)
                            .Include(c => c.Product)
                            .Skip(skip)
                            .Take(take)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<IEnumerable<Comments>> GetByUserId(string UserId, int skip = 0, int take = 10)
        {
            skip = skip * take;
            return await _context.Set<Comments>()
                            .Where(c => c.UserId == UserId  && c.Product.Status == true)
                            .Include(c => c.Product)
                            .Skip(skip)
                            .Take(take)
                            .AsNoTracking()
                            .ToListAsync();
        }
    }
}