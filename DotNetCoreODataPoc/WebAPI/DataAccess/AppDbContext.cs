using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.ModelConfigurations;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); // Configurations also can be added in a seperate class
            
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supplier>()
                .HasData(
                    new Supplier
                    { 
                        SupplierId = 1,
                        Name = "Supplier1"
                    },
                    new Supplier
                    {
                        SupplierId = 2,
                        Name = "Supplier2"
                    }
                );
        }
    }
}
