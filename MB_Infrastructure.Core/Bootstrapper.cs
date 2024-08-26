using MB_Application.ArticleCategoryAgg;
using MB_Application.Contracts.ArticleCategory;
using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Context;
using MB_Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB_Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddDbContext<MBContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
