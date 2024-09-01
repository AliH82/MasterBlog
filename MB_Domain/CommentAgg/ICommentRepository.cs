using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        Comment Getby(int id);
        void Save();
        List<Comment> GetAll();
    }
}
