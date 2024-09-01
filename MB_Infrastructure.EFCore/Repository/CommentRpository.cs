using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MasterBlogContext _context;

        public CommentRepository(MasterBlogContext context)
        {
            _context = context;
        }

        public void Create(Comment comment)
        {
            _context.Comment.Add(comment);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comment.ToList();
        }

        public Comment Getby(int id)
        {
            return _context.Comment.FirstOrDefault(c => c.Id == id);
        }
    }
}
