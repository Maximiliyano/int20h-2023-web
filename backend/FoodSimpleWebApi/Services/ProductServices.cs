using FoodSimpleWebApi.Data;
using FoodSimpleWebApi.Enums;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Services;

public sealed class ProductServices : BaseService
{
    public ProductServices(FoodSimpleDbContext context) : base(context) { }

    public async Task<ProductDto> Create(ProductDto productDto)
    {
        await _context.Products.AddAsync(productDto);
        await _context.SaveChangesAsync();

        productDto.Id = _context.Products.FirstAsync(p => p.Name == productDto.Name).Id;
        return productDto;
    }

    public async Task<bool> Delete(int productId)
    {
        var productDto = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (productDto == null)
        {
            return false;
        }

        _context.Products.Remove(productDto);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ProductDto?> Get(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }
    
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }
}