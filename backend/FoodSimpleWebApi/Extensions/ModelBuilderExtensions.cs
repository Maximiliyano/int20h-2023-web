using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Helpers;
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
        var users = GenerateRandomUsers();
    }
    
    private static IEnumerable<UserDto> GenerateRandomUsers() {
        var randomUsers = new List<UserDto>();
        for (var i = 0; i < 10; i++) {
            randomUsers.Add(new UserDto {
                Name = AppHelper.RandomizeLowerLetters(5),
                Email = $"{AppHelper.RandomizeLowerLetters(10)}@gmail.com",
                Password = AppHelper.RandomizeCharsAndSymbol(12)
            });
        }
        return randomUsers;
    }

}