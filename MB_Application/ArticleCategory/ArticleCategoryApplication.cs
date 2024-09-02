using _01_Framework.Infrastructure;
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
        private readonly IUnitOfWork _unitOfWork;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(ArticleCategoryViewModel model)
        {
             _unitOfWork.BeginTran();
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
            _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(model.Id);
            articleCategory.Edit(model.Title);
            _unitOfWork.CommitTran();
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
             _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Remove();
            _unitOfWork.CommitTran();
        }

        public void Activate(int id)
        {
             _unitOfWork.BeginTran();
            var articleCategory = _articleCategoryRepository.Get(id);
            articleCategory.Activate();
            _unitOfWork.CommitTran();
        }
    }
}
