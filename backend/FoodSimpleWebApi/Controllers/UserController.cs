using FoodSimpleWebApi.Controllers.Base;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodSimpleWebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : GlobalApiController {
    private readonly UserServices _userServices;

    public UserController(UserServices userServices) {
        _userServices = userServices;
    }

<<<<<<< HEAD
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
=======
    [HttpGet]
    public async Task<IActionResult> GetAll() {
>>>>>>> 57e9b99 (очистив код та виправив декілька попереджень)
        return Ok(await _userServices.GetAll());
    }

    [HttpGet]
    [ActionName("Get")]
<<<<<<< HEAD
    public async Task<IActionResult> Get([FromRoute] int userId) {
        UserDto? user = await _userServices.Get(userId);
        return user != null
            ? Ok(user)
=======
    public async Task<IActionResult> Get(string email)
    {
        var user = await _userServices.Get(email);
        return user != null 
            ? Ok(user) 
>>>>>>> 1b7d31f (change logic userController)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto) {
        UserDto user = await _userServices.Create(userDto);
        return CreatedAtAction(nameof(Get), new { userId = user.Id }, user);
    }

    [HttpPut]
<<<<<<< HEAD
    public async Task<IActionResult> Update([FromBody] UserDto userDto) {
        UserDto? user = await _userServices.Update(userDto);
        return user != null
            ? Ok(user)
=======
    public async Task<IActionResult> Update([FromBody] UserDto userDto)
    {
        var user = await _userServices.UpdateProfile(userDto);
        return user != null 
            ? Ok(user) 
>>>>>>> 1f754b1 (complete services)
            : NotFound();
    }

    [HttpPut("add/product")]
    public async Task<IActionResult> AddProduct(string email, ProductDto productDto)
    {
        return Ok(await _userServices.AddProduct(email, productDto));
    }
    
    [HttpDelete("remove/product")]
    public async Task<IActionResult> RemoveProduct(string email, int productId)
    {
        return Ok(await _userServices.RemoveProduct(email, productId));
    }
    
    [HttpPut("add/recipe")]
    public async Task<IActionResult> AddRecipe(string email, RecipeDto recipeDto)
    {
        return Ok(await _userServices.AddRecipe(email, recipeDto));
    }
    
    [HttpDelete("remove/recipe")]
    public async Task<IActionResult> RemoveRecipe(string email, int recipeId)
    {
        return Ok(await _userServices.RemoveRecipe(email, recipeId));
    }

    [HttpDelete]
    [Route("{userId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int userId) {
        bool request = await _userServices.Delete(userId);
        return request ? Ok() : NotFound();
    }
}