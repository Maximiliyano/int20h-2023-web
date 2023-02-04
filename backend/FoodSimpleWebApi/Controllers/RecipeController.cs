using FoodSimpleWebApi.Controllers.Base;
using FoodSimpleWebApi.Enums;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodSimpleWebApi.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipeController : GlobalApiController
{
    private readonly RecipeServices _recipeServices;
    
    public RecipeController(RecipeServices recipeServices)
    {
        _recipeServices = recipeServices;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RecipeDto recipeDto)
    {
        var recipe = await _recipeServices.Add(recipeDto);
        return CreatedAtAction(nameof(Get), new { recipeId = recipe.Id }, recipe);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RecipeDto recipeDto)
    {
        var recipe = await _recipeServices.Update(recipeDto);
        return recipe != null 
            ? Ok(recipe) 
            : NotFound();
    }

    [HttpDelete]
    [Route("{recipeId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int recipeId)
    {
        var request = await _recipeServices.Delete(recipeId);
        return request
            ? Ok()
            : NotFound();
    }

    [HttpGet]
    [Route("{recipeId:int}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get([FromRoute] int recipeId)
    {
        var recipe = await _recipeServices.Get(recipeId);

        if (recipe == null)
        {
            return NotFound();
        }
        
        return Ok(recipe);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _recipeServices.GetAll());
    }

    [HttpGet("filteredBy")]
    public async Task<IActionResult> GetAllFilteredByDifficult([FromQuery] CookDifficult cookDifficult)
    {
        return Ok(await _recipeServices.GetAllFilteredByDifficult(cookDifficult));
    }
}