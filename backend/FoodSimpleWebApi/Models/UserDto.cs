using FoodSimpleWebApi.Constants;
using System.ComponentModel.DataAnnotations;

namespace FoodSimpleWebApi.Models;

public sealed class UserDto {
    public int Id { get; set; }

    [MaxLength(50)]
<<<<<<< HEAD
    public string Name { get; set; }
    
    [MaxLength(250)]
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }
    
    [MaxLength(65)]
    public string Password { get; set; }
    
=======
    public string? Name { get; set; }
    [MaxLength(250)]
    [RegularExpression(BaseConstants.Email)]
    public string? Email { get; set; }

    public string? Password { get; set; }

>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)
    public IEnumerable<ProductDto>? Products { get; set; }
    public IEnumerable<RecipeDto>? Recipes { get; set; }
}