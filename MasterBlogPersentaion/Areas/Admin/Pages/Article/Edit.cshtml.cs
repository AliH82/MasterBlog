using MB_Application.Contracts.Article;
using MB_Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterBlogPersentaion.Areas.Admin.Pages.Article
{
    public class EditModel : PageModel
    {
        public ArticleViewModel model { get; set; }
        public SelectList ArticleCategoryList { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }


        public void OnGet(int id)
        {
            model = _articleApplication.Get(id);
            ArticleCategoryList = new SelectList(_articleCategoryApplication.GetAll(),"Id","Title",model.ArticleCategoryId);
        }

        public IActionResult OnPost(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                _articleApplication.Edit(article);
                return RedirectToPage("./Index");
            }
            ArticleCategoryList = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title", model.ArticleCategoryId);
            return Page();
        }
    }
}
