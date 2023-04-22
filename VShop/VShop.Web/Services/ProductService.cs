using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services
{
    public class ProductService : IProductService
    {
        private const string? API_ENDPOINT = "/api/products/";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions? _options;

        private ProductViewModel? _object;
        private IEnumerable<ProductViewModel>? _list;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(API_ENDPOINT, content))
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _object = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                    return null;

            return _object;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            var productUpdate = new ProductViewModel();

            using (var response = await client.PutAsJsonAsync(API_ENDPOINT, model))
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    productUpdate = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                    return null;

            return productUpdate;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");

            using var response = await client.DeleteAsync(API_ENDPOINT + id);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<ProductViewModel> FindProductById(Guid id)
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(API_ENDPOINT + id))
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _object = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                    return null;

            return _object;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var client = _httpClientFactory.CreateClient("ProductApi");
            using (var response = await client.GetAsync(API_ENDPOINT))
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    _list = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                    return null;

            return _list;
        }
    }
}