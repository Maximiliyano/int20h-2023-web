using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Attributes;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

<<<<<<< HEAD
<<<<<<< HEAD
public sealed class ProductDto {
=======
public class ProductDto
=======
public sealed class ProductDto
>>>>>>> d528654 (added new feature)
{
>>>>>>> 1f754b1 (complete services)
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
<<<<<<< HEAD
    [RequiredGreaterThanZero]
<<<<<<< HEAD
    public int Count { get; set; }
<<<<<<< HEAD
=======
=======
>>>>>>> d528654 (added new feature)
    public string Count { get; set; }
>>>>>>> 57f828b (fetch requirment)
    
<<<<<<< HEAD
<<<<<<< HEAD
    public string Description { get; set; }
=======

    public string? Ingredient { get; set; }
>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)

=======
    public ProductUnit Unit { get; set; }
    
>>>>>>> 1f754b1 (complete services)
    public CategoryProduct Category { get; set; }
=======
    public string Unit { get; set; }
    
    public string Category { get; set; }
>>>>>>> d528654 (added new feature)
}