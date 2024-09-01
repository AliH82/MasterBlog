using MB_Application.Contracts.Article;
using MB_Application.Contracts.Comment;
using MB_Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application.CommentApp
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IArticleApplication _articleApplication;

        public CommentApplication(ICommentRepository commentRepository,
            IArticleApplication articleApplication)
        {
            _commentRepository = commentRepository;
            _articleApplication = articleApplication;
        }

        public void Cancell(int id)
        {
            var comment = _commentRepository.Getby(id);
            comment.Cancell();
            _commentRepository.Save();
        }

        public void Confirm(int id)
        {
            var comment = _commentRepository.Getby(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public void Create(CommentViewModel model)
        {
            var comment = new Comment(model.Name, model.Email, model.Message, model.ArticleId);
            _commentRepository.Create(comment);
        }

        public List<CommentViewModel> GetAll()
        {
            return _commentRepository.GetAll().Select(c =>
            new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                ArticleId = c.ArticleId,
                CreatedOn = c.CreatedOn.ToString(),
                Statuse = c.Statuse,
                Article = _articleApplication.Get(c.ArticleId).Title
            }).OrderByDescending(c => c.Id).ToList();
        }

        public CommentViewModel GetBy(int id)
        {
            var comment = _commentRepository.Getby(id);
            var viewComment = new CommentViewModel
            {
                Id = comment.Id,
                Name = comment.Name,
                Email = comment.Email,
                Message = comment.Message,
                ArticleId = comment.ArticleId,
                CreatedOn = comment.CreatedOn.ToString(),
                Statuse = comment.Statuse,
                Article = _articleApplication.Get(comment.ArticleId).Title
            };

            return viewComment;
        }
    }
}
