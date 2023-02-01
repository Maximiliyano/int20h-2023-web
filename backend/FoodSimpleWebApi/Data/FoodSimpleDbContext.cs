using FoodSimpleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Data;

public class FoodSimpleDbContext : DbContext
{
    public DbSet<RecipeDto> Recipes { get; set; }
    public DbSet<ProductDto> Products { get; set; }
    public DbSet<UserDto> Users { get; set; }
    
    public FoodSimpleDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Configure(); TODO
        //modelBuilder.Seed();
    }
}