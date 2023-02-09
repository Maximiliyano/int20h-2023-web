using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Constants;

namespace FoodSimpleWebApi.Models;

public sealed class UserDto
{
    public int Id { get; set; }
    
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }

    public IList<ProductDto> Products = new List<ProductDto>();
    
    public IList<RecipeDto> Recipes = new List<RecipeDto>();
}