using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SanclerAPI.Context;
using SanclerAPI.Models;
using SanclerAPI.Repository.Interfaces;

namespace SanclerAPI.Repository
{
    public class AssessmentRepository : Repository<Assessments>, IAssessmentRepository
    {
        public AssessmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Assessments> GetByIdWithProduct(int id)
        {
            return await _context.Assessments.Include(c => c.Product).FirstAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Assessments>> GetByProductId(int Id, int skip = 0, int take = 10)
        {
            return await Get(skip: skip, take: take)
                          .Where(c => c.Product.Id == Id && c.Product.Status == true)
                          .Include(c => c.Product)
                          .ToListAsync();
        }

        public async Task<IEnumerable<Assessments>> GetByUserId(string UserId, int skip = 0, int take = 10)
        {
            return await Get(skip: skip, take: take)  
                           .Where(c => c.UserId == UserId && c.Product.Status == true)
                           .Include(c => c.Product)
                           .ToListAsync();
        }
    }
}