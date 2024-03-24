using ECommerceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = "1", Name = "Phone", Price = 999.99m, Photo = "Phone.jpg"},
                new Product { Id = "2", Name = "Camera", Price = 899.99m, Photo = "Camera.jpg" },
                new Product { Id = "3", Name = "TV", Price = 699.99m, Photo = "TV.jpg" },
                new Product { Id = "4", Name = "Car", Price = 499.99m , Photo = "Car.jpg" },
                new Product { Id = "5", Name = "Laptop", Price = 499.99m , Photo = "Laptop.jpg" }
                
            );

            base.OnModelCreating(modelBuilder);
            //Added ByMe
            //modelBuilder.Entity<Product>().ToTable("Product");
        }

    }
}

