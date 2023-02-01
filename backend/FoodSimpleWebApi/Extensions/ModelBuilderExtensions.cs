using FoodSimpleWebApi.Models;
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

    private static IEnumerable<UserDto> GenerateRandomUsers()
    {
        return new[] { new UserDto() };
    }
}