using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<ProductViewModel?> Create(ProductViewModel model, string token);
    Task<ProductViewModel?> Update(ProductViewModel model, string token);
    Task<bool> Delete(Guid id, string token);
    Task<ProductViewModel?> GetById(Guid id, string token);
    Task<IEnumerable<ProductViewModel?>?> GetAll(string token);
}