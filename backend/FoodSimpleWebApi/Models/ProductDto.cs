using FoodSimpleWebApi.Enums;

namespace FoodSimpleWebApi.Models;

public sealed class ProductDto
{
    public int Id { get; set; }

    public int Count { get; set; }
    
    public string Description { get; set; }

    public CategoryProduct Category { get; set; }
}