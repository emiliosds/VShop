using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services
{
    public class ProductService : ServiceBase<ProductViewModel>, IProductService
    {
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory, "/api/products/") { }
    }
}