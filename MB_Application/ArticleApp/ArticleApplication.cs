using _01_Framework.Infrastructure;
using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.Article;
using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace MB_Application.ArticleApp
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(ArticleViewModel model)
        {
            _unitOfWork.BeginTran();
            Article article = new Article(model.Title, model.ShortDescription, model.Image, model.Content, model.ArticleCategoryId);
            _articleRepository.Create(article);
            _unitOfWork.CommitTran();
        }

        public void Edit(ArticleViewModel model)
        {
            _unitOfWork.BeginTran();
            Article article = _articleRepository.Get(model.Id);
            article.Edit(model.Title, model.ShortDescription, model.Image, model.Content, model.ArticleCategoryId);
            _unitOfWork.CommitTran();
        }

        public ArticleViewModel Get(int id)
        {
            var article = _articleRepository.Get(id);
            var articleViewModel = new ArticleViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                CreatedOn = article.CreatedOn.ToString(),
                IsDeleted = article.IsDeleted,
                ArticleCategoryId = article.ArticleCategoryId
            };
            return articleViewModel;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll().Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Title = a.Title,
                ShortDescription = a.ShortDescription,
                Image = a.Image,
                Content = a.Content,
                IsDeleted = a.IsDeleted,
                CreatedOn = a.CreatedOn.ToString(),
                ArticleCategoryId = a.ArticleCategoryId,
                ArticleCategory = _articleCategoryRepository.Get(a.ArticleCategoryId).Title
            }).OrderByDescending(a => a.Id).ToList();
        }

        public void Restore(int id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Restore();
            _unitOfWork.CommitTran();
        }

        public void Remove(int id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.Get(id);
            article.Remove();
            _unitOfWork.CommitTran();
        }
    }
}
