using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<ProductViewModel?> Create(ProductViewModel model);
    Task<ProductViewModel?> Update(ProductViewModel model);
    Task<bool> Delete(Guid id);
    Task<ProductViewModel?> GetById(Guid id);
    Task<IEnumerable<ProductViewModel?>?> GetAll();
}