using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class RecipeDto {
    public int Id { get; set; }

    public int CookingTime { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public IList<ProductDto>? Products { get; set; }

    public CookDifficult Difficult { get; set; }
}