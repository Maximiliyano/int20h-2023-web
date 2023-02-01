using FoodSimpleWebApi.Controllers.Base;
using FoodSimpleWebApi.Enums;
using FoodSimpleWebApi.Models;
using FoodSimpleWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodSimpleWebApi.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : GlobalApiController
{
    private readonly ProductServices _productServices;
    
    public ProductController(ProductServices productServices)
    {
        _productServices = productServices;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductDto productDto)
    {
        var product = await _productServices.Create(productDto);
        return CreatedAtAction(nameof(Get), new { productId = product.Id }, product);
    }
    
    [HttpDelete]
    [Route("{productId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int productId)
    {
        var request = await _productServices.Delete(productId);
        return request
            ? Ok()
            : NotFound();
    }

    [HttpGet]
    [Route("{productId:int}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get([FromRoute] int productId)
    {
        var product = await _productServices.Get(productId);

        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productServices.GetAll());
    }

    [HttpGet("filteredBy")]
    public async Task<IActionResult> GetAllFilteredByDifficult([FromQuery] CategoryProduct categoryProduct)
    {
        return Ok(await _productServices.GetAllFilteredByCategory(categoryProduct));
    }
}