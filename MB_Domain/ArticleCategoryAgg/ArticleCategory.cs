using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;

namespace MB_Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreatedOn = DateTime.Now;
            Articles = new List<Article>();
        }

        public void Edit(string title)
        {
            Validation(title);
            Title = title;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }

        public void Validation(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
    }
}
