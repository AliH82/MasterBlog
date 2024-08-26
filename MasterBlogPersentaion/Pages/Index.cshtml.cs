using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.ArticleCategory;
using MB_Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogPersentaion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void OnGet()
        {
        }
    }
}
