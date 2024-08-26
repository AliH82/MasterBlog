using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogPersentaion.Areas.Admin.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ArticleCategoryViewModel model { get; set; }

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }


        public void OnGet(int id)
        {
            model = _articleCategoryApplication.Get(id);
        }

        public IActionResult OnPost(ArticleCategoryViewModel model)
        {
            if(model != null && ModelState.IsValid)
            {
                _articleCategoryApplication.Edit(model);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
