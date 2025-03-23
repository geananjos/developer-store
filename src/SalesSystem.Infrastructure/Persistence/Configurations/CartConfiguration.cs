using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Domain.Carts;

namespace SalesSystem.Infrastructure.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> entity)
        {
            entity.ToTable("carts");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.UserId).IsRequired();
            entity.Property(c => c.Date).IsRequired();

            entity.OwnsMany(c => c.Products, products =>
            {
                products.ToTable("cart_products");

                products.WithOwner().HasForeignKey("CartId");
                products.HasKey("CartId", "ProductId");

                products.Property(p => p.ProductId).IsRequired();
                products.Property(p => p.Quantity).IsRequired();

                products.Property(p => p.Discount)
                        .HasColumnType("decimal(5,2)")
                        .IsRequired();
            });
        }
    }
}
