using System.Threading.Tasks;
using SanclerAPI.Repository.Interfaces;
using SanclerAPI.Context;

namespace SanclerAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductRepository _ProductRepo;
        private CommentRepository _CommentRepo;
        private InventoryRepository _InventoryRepo;
        private ApplicationDbContext _context;
        private AssessmentRepository _AssesssmentRepo;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _ProductRepo = _ProductRepo ?? new ProductRepository(_context);
            }
        }

        public ICommentRepository CommentRepository 
        {
            get
            {
                return _CommentRepo = _CommentRepo ?? new CommentRepository(_context);
            }
        }

        public IInventoryRepository InventoyRepository 
        {
            get 
            {
                return _InventoryRepo = _InventoryRepo ?? new InventoryRepository(_context);
            }
        }

        public IAssessmentRepository AssessmentRepository  
        {
            get 
            {
                return _AssesssmentRepo = _AssesssmentRepo ?? new AssessmentRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}