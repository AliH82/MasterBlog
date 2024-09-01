using MasterBlogPersentaion.Areas.Admin.Pages.Comment;
using MasterBlogPersentaion.Eums;
using MB_Application.Contracts.Article;
using MB_Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MasterBlogPersentaion.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleViewModel model { get; set; }
        public List<CommentViewModel> CommenstList { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleApplication articleApplication, ICommentApplication commentApplication)
        {
            _articleApplication = articleApplication;
            _commentApplication = commentApplication;
        }

        public void OnGet(int id)
        {
            model = _articleApplication.Get(id);
            CommenstList = _commentApplication.GetAll().Where(c => c.ArticleId == id && c.Statuse == StatuseComment.Confirm).ToList();
        }

        public IActionResult OnPost(CommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _commentApplication.Create(model);
                return RedirectToPage("./ArticleDetails", new { id = model.ArticleId });
            }
            return RedirectToPage("./ArticleDetails", new { id = model.ArticleId });
        }
    }
}
