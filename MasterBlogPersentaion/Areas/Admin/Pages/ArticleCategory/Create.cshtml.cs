using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogPersentaion.Areas.Admin.Pages.ArticleCategory
{
    public class CreateModel : PageModel
    {
        public ArticleCategoryViewModel model {get; set;}
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(ArticleCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _articleCategoryApplication.Create(model);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
