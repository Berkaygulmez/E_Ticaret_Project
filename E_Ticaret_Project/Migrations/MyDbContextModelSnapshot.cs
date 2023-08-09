﻿// <auto-generated />
using System;
using E_Ticaret_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Ticaret_Project.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Ticaret_Project.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Piece")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("RegisterID")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("ProductID");

                    b.HasIndex("RegisterID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.HomeSlider", b =>
                {
                    b.Property<int>("SliderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SliderImageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderPhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SliderID");

                    b.ToTable("HomeSliders");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Piece")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("RegisterID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ProductID");

                    b.HasIndex("RegisterID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("TrademarkID")
                        .HasColumnType("int");

                    b.Property<int>("VersionID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.ProductImage", b =>
                {
                    b.Property<int>("ProductImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductImageID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Register", b =>
                {
                    b.Property<int>("RegisterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegisterID");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.RegisterAddress", b =>
                {
                    b.Property<int>("RegisterAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegisterID")
                        .HasColumnType("int");

                    b.HasKey("RegisterAddressID");

                    b.HasIndex("RegisterID");

                    b.ToTable("RegisterAddresses");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Trademark", b =>
                {
                    b.Property<int>("TrademarkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("TrademarkName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrademarkID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Trademarks");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Version", b =>
                {
                    b.Property<int>("VersionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TrademarkID")
                        .HasColumnType("int");

                    b.Property<string>("VersionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VersionID");

                    b.HasIndex("TrademarkID");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Cart", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Ticaret_Project.Models.Register", "Register")
                        .WithMany()
                        .HasForeignKey("RegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Order", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Ticaret_Project.Models.Register", "Register")
                        .WithMany()
                        .HasForeignKey("RegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Register");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Product", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.ProductImage", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Product", "product")
                        .WithOne("ProductImage")
                        .HasForeignKey("E_Ticaret_Project.Models.ProductImage", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.RegisterAddress", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Register", "Register")
                        .WithMany()
                        .HasForeignKey("RegisterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Register");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Trademark", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Version", b =>
                {
                    b.HasOne("E_Ticaret_Project.Models.Trademark", "Trademark")
                        .WithMany()
                        .HasForeignKey("TrademarkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trademark");
                });

            modelBuilder.Entity("E_Ticaret_Project.Models.Product", b =>
                {
                    b.Navigation("ProductImage");
                });
#pragma warning restore 612, 618
        }
    }
}
