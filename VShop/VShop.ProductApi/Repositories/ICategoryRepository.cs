using System.Linq.Expressions;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    Task<IEnumerable<Category>> GetCategoriesProducts(Expression<Func<Category, bool>>? filter = null);
}