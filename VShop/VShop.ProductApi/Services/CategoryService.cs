using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task AddCategory(CategoryDTO dto)
    {
        var entity = _mapper.Map<Category>(dto);
        await _categoryRepository.Add(entity);
        dto.Id = entity.Id;
    }

    public async Task UpdateCategory(CategoryDTO dto)
    {
        var entity = _mapper.Map<Category>(dto);
        await _categoryRepository.Update(entity);
    }

    public async Task RemoveCategory(Guid id)
    {
        await _categoryRepository.Delete(id);
    }

    public async Task<CategoryDTO> GetCategoryById(Guid id)
    {
        var entity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(entity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var entity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(entity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var entity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(entity);
    }
}