using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Domain.Products;

namespace SalesSystem.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("products");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
            entity.Property(p => p.Description).HasMaxLength(500);
            entity.Property(p => p.Category).HasMaxLength(100);
            entity.Property(p => p.Image).HasMaxLength(255);

            entity.OwnsOne(p => p.Rating, rating =>
            {
                rating.Property(r => r.Rate).HasColumnName("rating_rate").HasColumnType("decimal(3,2)");
                rating.Property(r => r.Count).HasColumnName("rating_count");
            });
        }
    }
}
