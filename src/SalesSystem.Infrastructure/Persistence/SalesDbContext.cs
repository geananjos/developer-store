using Microsoft.EntityFrameworkCore;
using SalesSystem.Domain.Carts;
using SalesSystem.Domain.Products;
using SalesSystem.Domain.Users;
using SalesSystem.Infrastructure.Persistence.Configurations;

namespace SalesSystem.Infrastructure.Persistence
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Cart> Carts => Set<Cart>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
        }

    }
}
