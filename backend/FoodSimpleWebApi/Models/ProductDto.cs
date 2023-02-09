using System.ComponentModel.DataAnnotations;
using FoodSimpleWebApi.Attributes;
using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class ProductDto
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    public string Count { get; set; }
    
    public string Unit { get; set; }
    
    public string Category { get; set; }
}