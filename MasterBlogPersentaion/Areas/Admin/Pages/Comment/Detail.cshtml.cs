using MB_Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterBlogPersentaion.Areas.Admin.Pages.Comment
{
    public class DetailModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public CommentViewModel model { get; set; }

        public DetailModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(int id)
        {
            model = _commentApplication.GetBy(id);
        }
    }
}
