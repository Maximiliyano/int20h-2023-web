using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Constants;

namespace FoodSimpleWebApi.Models;

public class UserDto
{
    public int Id { get; set; }
    
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }

    public IList<ProductDto>? Products { get; set; }
    
    public IList<RecipeDto>? Recipes { get; set; }
}