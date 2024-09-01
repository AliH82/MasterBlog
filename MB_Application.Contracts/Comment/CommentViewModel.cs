using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string CreatedOn { get; set; }
        public int Statuse { get; set; }
        public string Article { get; set; }
    }
}
