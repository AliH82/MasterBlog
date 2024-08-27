﻿using MB_Domain.ArticleAgg;
using MB_Domain.ArticleCategoryAgg;
using MB_Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB_Infrastructure.EFCore.Context
{
    public class MBContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Article> Article { get; set; }

        public MBContext(DbContextOptions<MBContext> option) : base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            modelBuilder.ApplyConfiguration(new ArticleMapping());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
