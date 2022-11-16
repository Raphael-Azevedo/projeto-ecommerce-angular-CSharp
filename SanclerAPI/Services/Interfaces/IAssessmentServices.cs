using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;

namespace SanclerAPI.Services.Interfaces
{
    public interface IAssessmentServices
    {
        Task<AssessmentConteiner> GetById(int id);
        Task<IEnumerable<AssessmentConteiner>> GetByUserId(int skip, int take, ClaimsPrincipal User);
        Task<IEnumerable<AssessmentConteiner>> GetByProductId(int id, int skip, int take);
        Task Create(CreateAssessmentDTO assessmentDto, ClaimsPrincipal User);
        Task Delete(int id, ClaimsPrincipal User);
        Task Update(int id, UpdateAssessmentsDTO assessmentsDto, ClaimsPrincipal User);
    }
}