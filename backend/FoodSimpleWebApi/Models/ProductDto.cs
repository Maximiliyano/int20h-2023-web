using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Attributes;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public class ProductDto
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [RequiredGreaterThanZero]
    public string Count { get; set; }
    
    public ProductUnit Unit { get; set; }
    
    public CategoryProduct Category { get; set; }
}