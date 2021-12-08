using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoffeeMaster.Models
{
    public class CoffeeMasterContext : DbContext
    {
        public CoffeeMasterContext(DbContextOptions<CoffeeMasterContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderManager> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                 new Customer
                 {
                     Id = 1,
                     Name = "Olivia Snakeroot",
                     Email = "osnake@gmail.com",
                     Phone = "231-555-2312",
                     Rewards = 12
                 },
                 new Customer
                 {
                     Id = 2,
                     Name = "Jake Martian",
                     Email = "jake@gmail.com",
                     Phone = "231-555-4512",
                     Rewards = 3
                 },
                 new Customer
                 {
                     Id = 3,
                     Name = "Jan Smith",
                     Email = "jmisth@gmail.com",
                     Phone = "231-555-4121",
                     Rewards = 55
                 }
             );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Lg Coffee",
                    Description = "Fresh brew from BRC",
                    Price = 3.00m,
                    Type = Product.ProductType.Drink
                },
                new Product
                {
                    Id = 2,
                    Name = "Md Coffee",
                    Description = "Fresh brew from BRC",
                    Price = 2.00m,
                    Type = Product.ProductType.Drink
                },
                new Product
                {
                    Id = 3,
                    Name = "Sm Coffee",
                    Description = "Fresh brew from BRC",
                    Price = 1.00m,
                    Type = Product.ProductType.Drink
                },
                new Product
                {
                    Id = 4,
                    Name = "Blueberry Muffin",
                    Description = "Delicious suger glazed treat",
                    Price = 2.00m,
                    Type = Product.ProductType.Food
                },
                new Product
                {
                    Id = 5,
                    Name = "Sm T-Shirt",
                    Description = "Soft Cotton-Blend",
                    Price = 20.00m,
                    Type = Product.ProductType.Swag
                });

            modelBuilder.Entity<OrderManager>().HasData(
                new OrderManager
                {
                    Id=1,
                    OrderedProduct = new List<Product>().FindAll(i => i.Id == 1 && i.Id == 2),
                    CustomerId = 1,
                    IsPaid = true,
                    IsServed = true,
                },
                new OrderManager
                {
                    Id = 2,
                    OrderedProduct = new List<Product>().FindAll(i => i.Id == 4 && i.Id == 5),
                    CustomerId = 2,
                    IsPaid = false,
                    IsServed = true,
                }
                );
        }
    }
}
