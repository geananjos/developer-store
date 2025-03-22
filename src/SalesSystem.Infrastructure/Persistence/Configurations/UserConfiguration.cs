using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.Domain.Users;

namespace SalesSystem.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users");

            entity.HasKey(u => u.Id);

            entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
            entity.Property(u => u.Phone).HasMaxLength(20);
            entity.Property(u => u.Status).HasConversion<string>().IsRequired();
            entity.Property(u => u.Role).HasConversion<string>().IsRequired();

            entity.OwnsOne(u => u.Name, name =>
            {
                name.Property(n => n.Firstname).HasColumnName("firstname").IsRequired().HasMaxLength(50);
                name.Property(n => n.Lastname).HasColumnName("lastname").IsRequired().HasMaxLength(50);
            });

            entity.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.City).HasColumnName("city").IsRequired().HasMaxLength(100);
                address.Property(a => a.Street).HasColumnName("street").IsRequired().HasMaxLength(100);
                address.Property(a => a.Number).HasColumnName("number").IsRequired();
                address.Property(a => a.Zipcode).HasColumnName("zipcode").HasMaxLength(20);

                address.OwnsOne(a => a.Geolocation, geo =>
                {
                    geo.Property(g => g.Lat).HasColumnName("lat").HasMaxLength(50);
                    geo.Property(g => g.Long).HasColumnName("long").HasMaxLength(50);
                });
            });
        }
    }
}
