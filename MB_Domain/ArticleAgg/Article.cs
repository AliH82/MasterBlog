using MB_Domain.ArticleCategoryAgg;
using System;

namespace MB_Domain.ArticleAgg
{
    public class Article
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public int ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {
        }

        public Article(string title, string shortDescription, string image, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }

        public void Edit(string title, string shortDescription, string image, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
