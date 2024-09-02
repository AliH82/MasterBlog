using _01_Framework.Infrastructure;
using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : Repository<int, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBlogContext _context;
        public ArticleCategoryRepository(MasterBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
