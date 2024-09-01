using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB_Infrastructure.EFCore.Context
{
    public class MasterBlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public MasterBlogContext(DbContextOptions<MasterBlogContext> option) : base(option)
        {
            
        }

        protected MasterBlogContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new CommentMapping());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
