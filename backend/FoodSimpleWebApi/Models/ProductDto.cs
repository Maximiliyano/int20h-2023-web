using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class ProductDto {
    public int Id { get; set; }

    public int Count { get; set; }
<<<<<<< HEAD
    
    public string Description { get; set; }
=======

    public string? Ingredient { get; set; }
>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)

    public CategoryProduct Category { get; set; }
}