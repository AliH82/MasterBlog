using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MBContext _context;

        public ArticleRepository(MBContext context)
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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
