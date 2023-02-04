using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Attributes;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

<<<<<<< HEAD
public sealed class ProductDto {
=======
public class ProductDto
{
>>>>>>> 1f754b1 (complete services)
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [RequiredGreaterThanZero]
<<<<<<< HEAD
    public int Count { get; set; }
<<<<<<< HEAD
=======
    public string Count { get; set; }
>>>>>>> 57f828b (fetch requirment)
    
<<<<<<< HEAD
    public string Description { get; set; }
=======

    public string? Ingredient { get; set; }
>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)

=======
    public ProductUnit Unit { get; set; }
    
>>>>>>> 1f754b1 (complete services)
    public CategoryProduct Category { get; set; }
}