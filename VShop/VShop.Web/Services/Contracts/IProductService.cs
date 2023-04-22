using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();

    Task<ProductViewModel> FindProductById(Guid id);

    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);

    Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);

    Task<bool> DeleteProduct(Guid id);
}