using System.Collections.Generic;

namespace MB_Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article Get(int id);
        void Create(Article article);
        void Edit(Article article);
        void Save();
    }
}
