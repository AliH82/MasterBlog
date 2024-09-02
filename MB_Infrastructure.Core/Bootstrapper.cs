using _01_Framework.Infrastructure;
using MB_Application.ArticleApp;
using MB_Application.ArticleCategoryAgg;
using MB_Application.CommentApp;
using MB_Application.Contracts.Article;
using MB_Application.Contracts.ArticleCategory;
using MB_Application.Contracts.Comment;
using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Domain.ArticleCategoryAgg.Services;
using MB_Domain.CommentAgg;
using MB_Infrastructure.EFCore.Context;
using MB_Infrastructure.EFCore.Repository;
using MB_Infrastructure.EFCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB_Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<MasterBlogContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            //services.AddTransient<IRepository, Repository>();
            services.AddTransient<IUnitOfWork, UnitOfWorkEf>();

        }
    }
}
