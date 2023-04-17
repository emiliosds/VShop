using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;
public class ProductRepository : Repository<Product>
{
    protected ProductRepository(AppDbContext context) : base(context) { }
}