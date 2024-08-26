using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogPersentaion.Areas.Admin.Pages.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategoryList { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategoryList = _articleCategoryApplication.GetAll();
        }

                                
        public IActionResult OnGetRemove(int id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetActivate(int id)
        {
            _articleCategoryApplication.Activate(id);
            return RedirectToPage("Index");
        }
    }
}
