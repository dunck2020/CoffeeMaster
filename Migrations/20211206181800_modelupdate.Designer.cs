// <auto-generated />
using System;
using CoffeeMaster.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoffeeMaster.Migrations
{
    [DbContext(typeof(CoffeeMasterContext))]
    [Migration("20211206181800_modelupdate")]
    partial class modelupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoffeeMaster.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarChar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rewards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "osnake@gmail.com",
                            Name = "Olivia Snakeroot",
                            Phone = "231-555-2312",
                            Rewards = 12
                        },
                        new
                        {
                            Id = 2,
                            Email = "jake@gmail.com",
                            Name = "Jake Martian",
                            Phone = "231-555-4512",
                            Rewards = 3
                        },
                        new
                        {
                            Id = 3,
                            Email = "jmisth@gmail.com",
                            Name = "Jan Smith",
                            Phone = "231-555-4121",
                            Rewards = 55
                        });
                });

            modelBuilder.Entity("CoffeeMaster.Models.OrderManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsServed")
                        .HasColumnType("bit");

                    b.Property<int>("RewardValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CoffeeMaster.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarChar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarChar(100)");

                    b.Property<int?>("OrderManagerId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderManagerId1")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderManagerId");

                    b.HasIndex("OrderManagerId1");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fresh brew from BRC",
                            Name = "Lg Coffee",
                            Price = 3.00m,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fresh brew from BRC",
                            Name = "Md Coffee",
                            Price = 2.00m,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fresh brew from BRC",
                            Name = "Sm Coffee",
                            Price = 1.00m,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Delicious suger glazed treat",
                            Name = "Blueberry Muffin",
                            Price = 2.00m,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Soft Cotton-Blend",
                            Name = "Sm T-Shirt",
                            Price = 20.00m,
                            Type = 2
                        });
                });

            modelBuilder.Entity("CoffeeMaster.Models.OrderManager", b =>
                {
                    b.HasOne("CoffeeMaster.Models.Customer", "CustomerOrder")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerOrder");
                });

            modelBuilder.Entity("CoffeeMaster.Models.Product", b =>
                {
                    b.HasOne("CoffeeMaster.Models.OrderManager", null)
                        .WithMany("AllProducts")
                        .HasForeignKey("OrderManagerId");

                    b.HasOne("CoffeeMaster.Models.OrderManager", null)
                        .WithMany("OrderedProduct")
                        .HasForeignKey("OrderManagerId1");
                });

            modelBuilder.Entity("CoffeeMaster.Models.OrderManager", b =>
                {
                    b.Navigation("AllProducts");

                    b.Navigation("OrderedProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
