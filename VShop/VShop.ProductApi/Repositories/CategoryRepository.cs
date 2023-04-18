using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;
public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Category>> GetCategoriesProducts(Expression<Func<Category, bool>>? filter = null)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
            query = query.Where(filter).AsNoTracking();

        return await query.Include(o => o.Products).ToListAsync();
    }
}