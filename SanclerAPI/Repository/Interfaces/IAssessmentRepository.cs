using System.Collections.Generic;
using System.Threading.Tasks;
using SanclerAPI.Models;

namespace SanclerAPI.Repository.Interfaces
{
    public interface IAssessmentRepository : IRepository<Assessments>
    {
        Task<IEnumerable<Assessments>> GetByUserId(string UserId, int skip = 0, int take = 10);
        Task<IEnumerable<Assessments>> GetByProductId(int Id, int skip = 0, int take = 10);
        Task<Assessments> GetByIdWithProduct(int id);
    }
}