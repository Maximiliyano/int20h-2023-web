using FoodSimpleWebApi.Extensions;
using FoodSimpleWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Data;

public class FoodSimpleDbContext : DbContext {
    public DbSet<RecipeDto> Recipes { get; set; }
    public DbSet<ProductDto> Products { get; set; }
    public DbSet<UserDto> Users { get; set; }

    public FoodSimpleDbContext(DbContextOptions options) : base(options) { }
<<<<<<< HEAD
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO uncomment this after complete
        //modelBuilder.Configure();
<<<<<<< HEAD
=======

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //modelBuilder.Configure(); TODO
>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)
        //modelBuilder.Seed();
=======
        modelBuilder.Seed();
>>>>>>> 1f754b1 (complete services)
    }
}