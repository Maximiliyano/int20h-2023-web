using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Attributes;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class RecipeDto
{
    public int Id { get; set; }
    
    [RequiredGreaterThanZero]
    public int CookingTime { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(250)]
    public string Description { get; set; }
    
    public IList<ProductDto> Products { get; set; }

    public CookDifficult Difficult { get; set; }
}