using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MBContext _context;

        public ArticleCategoryRepository(MBContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory entity)
        {
            _context.ArticleCategory.Add(entity);
            Save();
        }

        public ArticleCategory Get(int id)
        {
            return _context.ArticleCategory.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(ArticleCategory entity)
        {
            ArticleCategory article = Get(entity.Id);
            article.Edit(article.Title);
            Save();
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategory.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Exist(string title)
        {
            return _context.ArticleCategory.Any(x => x.Title == title);
        }
    }
}
