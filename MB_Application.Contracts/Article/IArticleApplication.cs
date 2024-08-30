using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll();
        ArticleViewModel Get(int id);
        void Create(ArticleViewModel model);
        void Edit(ArticleViewModel model);
        void Remove(int id);
        void Restore(int id);
    }
}
