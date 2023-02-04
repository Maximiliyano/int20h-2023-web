using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Constants;

namespace FoodSimpleWebApi.Models;

public class UserDto
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(250)]
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }
    
    [MaxLength(65)]
    public string Password { get; set; }

    public IList<ProductDto>? Products { get; set; }
    
    public IList<RecipeDto>? Recipes { get; set; }
}