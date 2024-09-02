using _01_Framework.Infrastructure;
using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class CommentRepository : Repository<int, Comment>, ICommentRepository
    {
        private readonly MasterBlogContext _context;
        public CommentRepository(MasterBlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
