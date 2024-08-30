using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBlogContext _context;

        public ArticleRepository(MasterBlogContext context)
        {
            _context = context;
        }

        public void Create(Article article)
        {
            _context.Article.Add(article);
            Save();
        }

        public List<Article> GetAll()
        {
            return _context.Article.ToList();
        }

        public Article Get(int id)
        {
            return _context.Article.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Article article)
        {
            var entity = Get(article.Id);
            entity.Edit(article.Title,article.ShortDescription,article.Image,article.Content,article.ArticleCategoryId);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
