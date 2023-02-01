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

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        return Ok(await _userServices.GetAll());
    }

    [HttpGet]
    [Route("{userId:int}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get([FromRoute] int userId) {
        UserDto? user = await _userServices.Get(userId);
        return user != null
            ? Ok(user)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto userDto) {
        UserDto user = await _userServices.Create(userDto);
        return CreatedAtAction(nameof(Get), new { userId = user.Id }, user);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto userDto) {
        UserDto? user = await _userServices.Update(userDto);
        return user != null
            ? Ok(user)
            : NotFound();
    }

    [HttpDelete]
    [Route("{userId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int userId) {
        bool request = await _userServices.Delete(userId);
        return request ? Ok() : NotFound();
    }
}