using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Constants;

namespace FoodSimpleWebApi.Models;

public sealed class UserDto
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(250)]
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public IEnumerable<ProductDto>? Products { get; set; }
    public IEnumerable<RecipeDto>? Recipes { get; set; }
}