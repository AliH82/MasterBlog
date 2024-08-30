using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.Article;
using MB_Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MasterBlogPersentaion.Areas.Admin.Pages.Article
{
    public class CreateModel : PageModel
    {
        public ArticleViewModel model { get; set; }
        public SelectList ArticleCategoryList { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategoryList = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Title");
        }

        public IActionResult OnPost(ArticleViewModel article)
        {
            if (ModelState.IsValid)
            {
                _articleApplication.Create(article);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
