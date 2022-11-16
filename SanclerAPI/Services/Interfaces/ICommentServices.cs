using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using SanclerAPI.DTO;
using SanclerAPI.HATEOAS.Conteiners;

namespace SanclerAPI.Services.Interfaces
{
    public interface ICommentServices
    {
        Task<CommentConteiner> GetById(int id);
        Task<IEnumerable<CommentConteiner>> GetByUserId(int skip, int take, ClaimsPrincipal User);
        Task<IEnumerable<CommentConteiner>> GetByProductId(int id, int skip, int take);
        Task Create(CreateCommentDTO commentDto, ClaimsPrincipal User);
        Task Update(int id, UpdateCommentDTO commentDto, ClaimsPrincipal User);
        Task Delete(int id, ClaimsPrincipal User);
    }
}