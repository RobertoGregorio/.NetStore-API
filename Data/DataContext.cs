using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        protected DbSet<Product> Products { get; set; }

        protected DbSet<Ordering> Orderings { get; set; }

        protected DbSet<Purchase> Purchases { get; set; }

        protected DbSet<Stock> Stock { get; set; }

        protected DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"#");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => c.Code).IsUnique();
            });
        }
    }
}