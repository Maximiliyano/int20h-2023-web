﻿using FoodSimpleWebApi.Constants;
using System.ComponentModel.DataAnnotations;

namespace FoodSimpleWebApi.Models;

<<<<<<< HEAD
public sealed class UserDto {
=======
public class UserDto
{
>>>>>>> 1f754b1 (complete services)
    public int Id { get; set; }
<<<<<<< HEAD

    [MaxLength(50)]
<<<<<<< HEAD
    public string Name { get; set; }
    
    [MaxLength(250)]
=======
    
>>>>>>> 57f828b (fetch requirment)
    [RegularExpression(BaseConstants.Email)]
    public string Email { get; set; }

    public IList<ProductDto>? Products { get; set; }
    
<<<<<<< HEAD
=======
    public string? Name { get; set; }
    [MaxLength(250)]
    [RegularExpression(BaseConstants.Email)]
    public string? Email { get; set; }

    public string? Password { get; set; }

>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)
    public IEnumerable<ProductDto>? Products { get; set; }
    public IEnumerable<RecipeDto>? Recipes { get; set; }
=======
    public IList<RecipeDto>? Recipes { get; set; }
>>>>>>> 1f754b1 (complete services)
}