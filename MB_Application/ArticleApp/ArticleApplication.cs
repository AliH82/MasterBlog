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
            _articleRepository.Save();
        }

        public List<ArticleViewModel> GetAll()
        {
            //_articleCategoryRepository.Get(a.ArticleCategoryId).Title
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
    }
}
