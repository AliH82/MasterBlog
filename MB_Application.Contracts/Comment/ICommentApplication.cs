using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Create(CommentViewModel model);
        List<CommentViewModel> GetAll();
        CommentViewModel GetBy(int id);
        void Cancell(int id);
        void Confirm(int id);
    }
}
