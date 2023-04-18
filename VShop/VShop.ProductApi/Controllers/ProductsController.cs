﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
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

    [HttpGet("{id:guid}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(Guid id)
    {
        var productDTO = await _productService.GetProductById(id);

        if (productDTO is null)
            return NotFound("Product not found");

        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Invalid data");

        await _productService.AddProduct(productDTO);

        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut("id:guid")]
    public async Task<ActionResult> Put(Guid id, [FromBody] ProductDTO productDTO)
    {
        if (id != productDTO.Id)
            return BadRequest();

        if (productDTO is null)
            return BadRequest();

        await _productService.UpdateProduct(productDTO);
        return Ok(productDTO);
    }

    [HttpDelete("id:guid")]
    public async Task<ActionResult<ProductDTO>> Delete(Guid id)
    {
        var productDTO = await _productService.GetProductById(id);
        if (productDTO is null)
            return NotFound("Product not found");

        await _productService.RemoveProduct(productDTO.Id);
        return Ok(productDTO);
    }
}