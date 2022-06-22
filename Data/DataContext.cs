using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Api.Domain;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected DbSet<Product> Products { get; set; }

        protected DbSet<Ordering> Orderings { get; set; }

        protected DbSet<Purchase> Purchases { get; set; }

        protected DbSet<Stock> Stock { get; set; }

        protected DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionString").GetSection("DefaultConnection").Value);
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