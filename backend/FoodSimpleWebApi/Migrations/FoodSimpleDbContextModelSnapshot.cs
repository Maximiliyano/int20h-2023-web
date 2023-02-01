﻿// <auto-generated />
using System;
using FoodSimpleWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodSimpleWebApi.Migrations
{
    [DbContext(typeof(FoodSimpleDbContext))]
    partial class FoodSimpleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Ingredient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeDtoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeDtoId");

                    b.HasIndex("UserDtoId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CookingTime")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficult")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserDtoId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.HasOne("FoodSimpleWebApi.Models.RecipeDto", null)
                        .WithMany("Products")
                        .HasForeignKey("RecipeDtoId");

                    b.HasOne("FoodSimpleWebApi.Models.UserDto", null)
                        .WithMany("Products")
                        .HasForeignKey("UserDtoId");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.HasOne("FoodSimpleWebApi.Models.UserDto", null)
                        .WithMany("Recipes")
                        .HasForeignKey("UserDtoId");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.UserDto", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}