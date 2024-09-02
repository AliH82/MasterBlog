using _01_Framework.Infrastructure;
using MB_Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace MB_Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<int, Article>
    {
        
    }
}
