using MB_Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MasterBlogPersentaion.Areas.Admin.Pages.Article
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
            ArticleList = _articleApplication.GetAll();
        }

        public IActionResult OnGetRemove(int id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetRestore(int id)
        {
            _articleApplication.Restore(id);
            return RedirectToPage("Index");
        }
    }
}
