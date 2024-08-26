using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure.EFCore.Context
{
    public class MBContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategory { get; set; }

        public MBContext(DbContextOptions<MBContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
