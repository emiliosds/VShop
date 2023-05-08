using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Roles;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var categories = await _productService.GetProducts();

        if (categories is null)
            return NotFound("Categories not found");

        return Ok(categories);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(Guid id)
    {
        var productDTO = await _productService.GetProductById(id);

        if (productDTO is null)
            return NotFound("Product not found");

        return Ok(productDTO);
    }

    [HttpPost]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Invalid data");

        await _productService.AddProduct(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult> Put([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest();

        await _productService.UpdateProduct(productDTO);

        return Ok(productDTO);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult<ProductDTO>> Delete(Guid id)
    {
        var productDTO = await _productService.GetProductById(id);
        if (productDTO is null)
            return NotFound("Product not found");

        await _productService.RemoveProduct(id);

        return Ok(productDTO);
    }
}