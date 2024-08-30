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


        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void Create(ArticleViewModel model)
        {
            Article article = new Article(model.Title, model.ShortDescription, model.Image, model.Content, model.ArticleCategoryId);
            _articleRepository.Create(article);
        }

        public void Edit(ArticleViewModel model)
        {
            Article article = _articleRepository.Get(model.Id);
            article.Edit(model.Title, model.ShortDescription, model.Image, model.Content, model.ArticleCategoryId);
            _articleRepository.Save();
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
            var article = _articleRepository.Get(id);
            article.Restore();
            _articleRepository.Save();
        }

        public void Remove(int id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
            _articleRepository.Save();
        }
    }
}
