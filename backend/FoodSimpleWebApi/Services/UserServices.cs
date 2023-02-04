using FoodSimpleWebApi.Data;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Services;

public sealed class UserServices : BaseService {
    public UserServices(FoodSimpleDbContext context) : base(context) { }

    public async Task<UserDto> Create(UserDto userDto) {
        await _context.Users.AddAsync(userDto);
        await _context.SaveChangesAsync();

        userDto.Id = _context.Users.FirstAsync(u => u.Name == userDto.Name).Id;
        return userDto;
    }

    public async Task<bool> Delete(int userId) {
        UserDto? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

<<<<<<< HEAD
    public async Task<UserDto?> Update(UserDto userDto) {
        UserDto? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);
=======
    public async Task<UserDto?> UpdateProfile(UserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);
>>>>>>> 1f754b1 (complete services)

        if (user == null) return user;

        user.Name = userDto.Name;
        user.Email = userDto.Email;

        await _context.SaveChangesAsync();

        return user;
    }

<<<<<<< HEAD
    public async Task<UserDto?> Get(int userId) {
=======
    public async Task<bool> AddProduct(int userId, ProductDto productDto)
    {
        var user = await Get(userId);
        var product = user?.Products.FirstOrDefault(p => p.Id == productDto.Id);

        if (user == null || product != null)
        {
            return false;
        }
        
        user.Products.Add(productDto);

        await _context.SaveChangesAsync();

        return false;
    }
    
    public async Task<bool> RemoveProduct(int userId, int productId)
    {
        var user = await Get(userId);
        var product = user?.Products.FirstOrDefault(p => p.Id == productId);

        if (user == null || product == null)
        {
            return false;
        }
        
        user.Products.Remove(product);

        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<UserDto?> AddRecipe(int userId, RecipeDto recipeDto)
    {
        var user = await Get(userId);

        if (user == null)
        {
            return user;
        }
        
        user.Recipes.Add(recipeDto);

        await _context.SaveChangesAsync();

        return user;
    }
    
    public async Task<bool> RemoveRecipe(int userId, int recipeId)
    {
        var user = await Get(userId);
        var recipe = user?.Recipes.FirstOrDefault(r => r.Id == recipeId);

        if (user == null || recipe == null)
        {
            return false;
        }
        
        user.Recipes.Remove(recipe);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<UserDto?> Get(int userId)
    {
>>>>>>> 1f754b1 (complete services)
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<IEnumerable<UserDto>> GetAll() {
        return await _context.Users.ToListAsync();
    }
}