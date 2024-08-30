using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.Article;
using MB_Application.Contracts.ArticleCategory;
using MB_Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogPersentaion.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> ArticleList { get; set; }
        private readonly IArticleApplication _articleApplication;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleList = _articleApplication.GetAll().Where(a => a.IsDeleted == false).ToList();
        }
    }
}
