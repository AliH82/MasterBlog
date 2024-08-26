using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Create(ArticleCategory entity);
        ArticleCategory Get(int id);
        void Edit(ArticleCategory entity);
        bool Exist(string title); 
        void Save();
    }
}
