using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.DataAccess.ModelConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");           
            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);
            builder.HasData
            (
                new Product
                { 
                    Id = 1,
                    Name = "Product1",
                    Price = 30,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    Price = 40,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Product3",
                    Price = 50,
                    SupplierId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Product4",
                    Price = 60,
                    SupplierId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Product5",
                    Price = 70,
                    SupplierId = 2
                }
            );
        }
    }
}
