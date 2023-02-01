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
        
        userDto.Id = _context.Users.FirstAsync(u => u.Name == userDto.Name).Id;
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

    public async Task<UserDto?> Update(UserDto userDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);

        if (user == null)
        {
            return user;
        }

        user.Name = userDto.Name;
        user.Email = userDto.Email;
        user.Recipes = userDto.Recipes;
        user.Products = userDto.Products;

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserDto?> Get(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
}