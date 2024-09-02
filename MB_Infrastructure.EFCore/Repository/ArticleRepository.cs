using _01_Framework.Infrastructure;
using MB_Domain.ArticleAgg;
using MB_Infrastructure.EFCore.Context;

namespace MB_Infrastructure.EFCore.Repository
{
    public class ArticleRepository : Repository<int, Article>, IArticleRepository
    {
        private readonly MasterBlogContext _context;
        public ArticleRepository(MasterBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
