using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Roles;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categories = await _categoryService.GetCategories();

        if (categories is null)
            return NotFound("Categories not found");

        return Ok(categories);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();

        if (categoriesDTO is null)
            return NotFound("Categories not found");

        return Ok(categoriesDTO);
    }

    [HttpGet("{id:guid}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(Guid id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if (categoryDTO is null)
            return NotFound("Category not found");

        return Ok(categoryDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Invalid data");

        await _categoryService.AddCategory(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
    }

    [HttpPut("id:guid")]
    public async Task<ActionResult> Put(Guid id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id)
            return BadRequest();

        if (categoryDTO is null)
            return BadRequest();

        await _categoryService.UpdateCategory(categoryDTO);
        return Ok(categoryDTO);
    }

    [HttpDelete("id:guid")]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult<CategoryDTO>> Delete(Guid id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category is null)
            return NotFound("Category not found");

        await _categoryService.RemoveCategory(category.Id);
        return Ok(category);
    }
}