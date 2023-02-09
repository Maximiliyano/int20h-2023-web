using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class RecipeDto
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
    
    public string Description { get; set; }

    public string? Image { get; set; }

    public IList<ProductDto> Products { get; set; }

    public CookDifficult Difficult { get; set; }
}