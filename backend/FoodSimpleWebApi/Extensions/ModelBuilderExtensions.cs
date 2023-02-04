using FoodSimpleWebApi.Enums;
using FoodSimpleWebApi.Helpers;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.StringFormats;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Extensions;

// TODO implement methods extension
public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>()
            .HasOne(u => u.Name)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        var products = GenerateRandomProducts(10);
        var recipes = GenerateRandomRecipes(10);
        var users = GenerateRandomUsers(10, products, recipes);

        modelBuilder.Entity<UserDto>().HasData(users);
        modelBuilder.Entity<ProductDto>().HasData(products);
        modelBuilder.Entity<RecipeDto>().HasData(recipes);
    }

    private static IEnumerable<UserDto> GenerateRandomUsers(int limit, IList<ProductDto> products, IList<RecipeDto> recipes)
    {
        var users = new List<UserDto>();
        
        for (var i = 0; i < limit/2; i++)
        {
            users.Add(BuildUserDto(i));
            users.Add(BuildUserDto(i, products, recipes));
        }
        return users;
    }

    private static IList<RecipeDto> GenerateRandomRecipes(int limit)
    {
        var products = new List<RecipeDto>();

        for (var i = 0; i < limit; i++)
        {
            products.Add(new RecipeDto());
        }
        
        return new[] { new RecipeDto() };
    }
    
    private static IList<ProductDto> GenerateRandomProducts(int limit)
    {
        var products = new List<ProductDto>();

        for (var i = 0; i < limit; i++)
        {
            products.Add(BuildProductDto(i));
        }
        return products;
    }

    private static UserDto BuildUserDto(int id, IList<ProductDto>? products = null, IList<RecipeDto>? recipes = null) =>
        new()
        {
            Id = id + 1,
            Email = string.Format(BaseFormat.Email, AppHelper.RandomizeCharacters(7)),
            Name = AppHelper.RandomizeCharacters(7),
            Password = AppHelper.RandomizeCharacters(6),
            Products = products,
            Recipes = recipes
        };

    private static ProductDto BuildProductDto(int id) =>
        new()
        {
            Id = id + 1,
            Category = (CategoryProduct)AppHelper.RandomCategoryProduct(),
            Count = AppHelper.RandomizeNumber(1, 10),
            Name = AppHelper.RandomizeCharacters(10),
            Unit = AppHelper.RandomProductUnit()
        };
}