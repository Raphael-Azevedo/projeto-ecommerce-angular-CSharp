using System.Threading.Tasks;

namespace SanclerAPI.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICommentRepository CommentRepository { get; }
        IInventoryRepository InventoyRepository { get; }
        IAssessmentRepository AssessmentRepository { get; }
        Task Commit();
    }
}