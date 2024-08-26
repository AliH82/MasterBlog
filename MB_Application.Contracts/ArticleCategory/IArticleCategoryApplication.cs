using MB_Application.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
namespace MB_Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetAll();
        void Create(ArticleCategoryViewModel model);
        ArticleCategoryViewModel Get(int id);
        void Edit(ArticleCategoryViewModel model);
        void Remove(int id);
        void Activate(int id);
    }
}
