using MB_Application.Contracts.ArticleCategory;
using MB_Domain.ArticleCategoryAgg;
using MB_Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace MB_Application.ArticleCategoryAgg
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Create(ArticleCategoryViewModel model)
        {
            ArticleCategory articleCategory = new ArticleCategory(model.Title);
            _articleCategoryRepository.Create(articleCategory);
        }

        public ArticleCategoryViewModel Get(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            var articleCategoryViewModel = new ArticleCategoryViewModel
            {
                Id = articleCategory.Id,
                Title = articleCategory.Title,
                CreatedOn = articleCategory.CreatedOn.ToString(),
                IsDeleted = articleCategory.IsDeleted,
            };
            return articleCategoryViewModel;
        }

        public void Edit(ArticleCategoryViewModel model)
        {
            var articleCategory = _articleCategoryRepository.Get(model.Id);
            articleCategory.Edit(model.Title);
            _articleCategoryRepository.Save();
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            return _articleCategoryRepository.GetAll().Select(a => new ArticleCategoryViewModel
            {
                Id = a.Id,
                Title = a.Title,
                CreatedOn = a.CreatedOn.ToString(),
                IsDeleted = a.IsDeleted,
            }).OrderByDescending(a => a.Id).ToList();
        }

        public void Remove(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _articleCategoryRepository.Save();
        }

        public void Activate(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _articleCategoryRepository.Save();
        }
    }
}
