using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public new async Task<Product?> GetById(Guid id)
    {
        return await _dbSet.Include(o => o.Category)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public new async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>>? filter = null)
    {
        var query = _dbSet.AsQueryable();

        if (filter != null)
            query = query.Where(filter)
                .AsNoTracking();

        return await query.Include(o => o.Category)
            .ToListAsync();
    }
}