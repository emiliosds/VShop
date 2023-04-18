using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface IProductService
{
    Task AddProduct(ProductDTO dto);
    Task UpdateProduct(ProductDTO dto);
    Task RemoveProduct(Guid id);
    Task<ProductDTO> GetProductById(Guid id);
    Task<IEnumerable<ProductDTO>> GetProducts();
}