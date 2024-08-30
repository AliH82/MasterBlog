using MB_Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogPersentaion.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleViewModel model { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ArticleDetailsModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet(int id)
        {
            model = _articleApplication.Get(id);
        }
    }
}
