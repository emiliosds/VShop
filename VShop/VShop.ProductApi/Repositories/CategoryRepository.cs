using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;
public class CategoryRepository : Repository<Category>
{
    protected CategoryRepository(AppDbContext context) : base(context) { }
}