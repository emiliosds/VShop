using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface ICategoryService
{
    Task AddCategory(CategoryDTO dto);
    Task UpdateCategory(CategoryDTO dto);
    Task RemoveCategory(Guid id);
    Task<CategoryDTO> GetCategoryById(Guid id);
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
}