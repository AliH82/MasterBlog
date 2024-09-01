using MB_Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MasterBlogPersentaion.Areas.Admin.Pages.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> CommentList { get; set; }
        private readonly ICommentApplication _commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            CommentList = _commentApplication.GetAll();
        }

        public IActionResult OnGetCancell(int id)
        {
            _commentApplication.Cancell(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetConfirm(int id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }
    }
}
