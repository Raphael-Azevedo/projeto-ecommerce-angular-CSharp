using System.Collections.Generic;
using System.Threading.Tasks;
using SanclerAPI.Models;

namespace SanclerAPI.Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comments>
    {
        Task<IEnumerable<Comments>> GetByUserId(string UserId, int skip = 0, int take = 10);
        Task<IEnumerable<Comments>> GetByProductId(int Id,  int skip = 0, int take = 10);
        Task<Comments> GetByIdWithProduct(int id);
    }
}