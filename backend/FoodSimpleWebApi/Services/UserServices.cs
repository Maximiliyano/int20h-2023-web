using FoodSimpleWebApi.Data;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Services;

public sealed class UserServices : BaseService
{
    public UserServices(FoodSimpleDbContext context) : base(context) { }

    public async Task<UserDto> Create(UserDto userDto)
    {
        await _context.Users.AddAsync(userDto);
        await _context.SaveChangesAsync();
        
        userDto.Id = _context.Users.FirstAsync(u => u.Email == userDto.Email).Id;
        return userDto;
    }

    public async Task<bool> Delete(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<UserDto?> UpdateProfile(UserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);

        if (user == null)
        {
            return user;
        }
        
        user.Email = userDto.Email;
        user.Products = userDto.Products;
        user.Recipes = userDto.Recipes;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> AddProduct(string email, ProductDto productDto)
    {
        var user = await Get(email);
        var product = user?.Products.FirstOrDefault(p => p.Id == productDto.Id);

        if (user == null || product != null)
        {
            return false;
        }
        
        user.Products.Add(productDto);

        await _context.SaveChangesAsync();

        return false;
    }
    
    public async Task<bool> RemoveProduct(string email, int productId)
    {
        var user = await Get(email);
        var product = user?.Products.FirstOrDefault(p => p.Id == productId);

        if (user == null || product == null)
        {
            return false;
        }
        
        user.Products.Remove(product);

        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<UserDto?> AddRecipe(string email, RecipeDto recipeDto)
    {
        var user = await Get(email);

        if (user == null)
        {
            return user;
        }
        
        user.Recipes.Add(recipeDto);

        await _context.SaveChangesAsync();

        return user;
    }
    
    public async Task<bool> RemoveRecipe(string email, int recipeId)
    {
        var user = await Get(email);
        var recipe = user?.Recipes.FirstOrDefault(r => r.Id == recipeId);

        if (user == null || recipe == null)
        {
            return false;
        }
        
        user.Recipes.Remove(recipe);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserDto?> Get(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
}