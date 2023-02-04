using FoodSimpleWebApi.Data;
using FoodSimpleWebApi.Enums;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi.Services;

public sealed class RecipeServices : BaseService
{
    public RecipeServices(FoodSimpleDbContext context) : base(context) { }

    public async Task<RecipeDto> Add(RecipeDto recipeDto)
    {
        await _context.Recipes.AddAsync(recipeDto);
        await _context.SaveChangesAsync();
        
        recipeDto.Id = _context.Recipes.FirstAsync(u => u.Name == recipeDto.Name).Id;
        return recipeDto;
    }

    public async Task<RecipeDto?> Update(RecipeDto recipeDto)
    {
        var recipe = await _context.Recipes.FirstOrDefaultAsync(u => u.Id == recipeDto.Id);

        if (recipe == null)
        {
            return recipe;
        }

        recipe.Name = recipeDto.Name;
        recipe.CookingTime = recipeDto.CookingTime;
        recipe.Description = recipeDto.Description;
        recipe.Products = recipeDto.Products;
        recipe.Difficult = recipeDto.Difficult;

        await _context.SaveChangesAsync();

        return recipe;
    }

    public async Task<bool> Delete(int recipeId)
    {
        var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);

        if (recipe == null)
        {
            return false;
        }

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<RecipeDto?> Get(int recipeId)
    {
        return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
    }

    public async Task<IEnumerable<RecipeDto>> GetAll()
    {
        return await _context.Recipes.ToListAsync();
    }
    
    public async Task<IEnumerable<RecipeDto>> GetAllFilteredByDifficult(CookDifficult cookDifficult)
    {
        var recipes = await GetAll();
        return from recipe in recipes
            where recipe.Difficult == cookDifficult
            select recipe;
    }
}