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
            .HasOne(u => u.Email)
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
        var concatLimit = limit / 2;
        var users = new List<UserDto>();
        
        for (var i = 0; i < concatLimit; i++)
        {
            users.Add(BuildUserDto(i, new List<ProductDto>(), new List<RecipeDto>()));
            users.Add(BuildUserDto(i + concatLimit, products, recipes));
        }
        return users;
    }

    private static IList<RecipeDto> GenerateRandomRecipes(int limit)
    {
        var recipes = new List<RecipeDto>();

        for (var i = 0; i < limit; i++)
        {
            recipes.Add(BuildRecipeDto(i));
        }
        
        return recipes;
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

    private static RecipeDto BuildRecipeDto(int id) =>
        new ()
        {
            Id = id + 1,
            Name = AppHelper.RandomizeCharacters(10),
            Description = AppHelper.RandomizeCharacters(500),
            Difficult = AppHelper.RandomCookDifficult()
        };
    
    private static UserDto BuildUserDto(int id, IList<ProductDto> products, IList<RecipeDto> recipes) =>
        new()
        {
            Id = id + 1,
            Email = string.Format(BaseFormat.Email, AppHelper.RandomizeCharacters(7)),
            Products = products,
            Recipes = recipes
        };

    private static ProductDto BuildProductDto(int id) =>
        new()
        {
            Id = id + 1,
            Category = AppHelper.RandomCategoryProduct().ToString(),
            Count = AppHelper.RandomizeNumber(1, 10).ToString(),
            Name = AppHelper.RandomizeCharacters(10),
            Unit = AppHelper.RandomProductUnit().ToString()
        };
}