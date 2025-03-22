using Microsoft.EntityFrameworkCore;
using SalesSystem.Domain.Products;

namespace SalesSystem.Infrastructure.Persistence
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Category).HasMaxLength(100);
                entity.Property(p => p.Image).HasMaxLength(255);

                // Value Object: Rating
                entity.OwnsOne(p => p.Rating, rating =>
                {
                    rating.Property(r => r.Rate).HasColumnName("rating_rate").HasColumnType("decimal(3,2)");
                    rating.Property(r => r.Count).HasColumnName("rating_count");
                });
            });
        }
    }
}
